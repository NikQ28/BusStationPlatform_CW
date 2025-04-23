using System;
using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services
{
    public class BookingService(IPlaceRepository _placeRepository, IRouteRepository _routeRepository, 
        ITicketRepository _ticketRepository, IInvoiceRepository _invoiceRepository) : IBookingService
    {
        public async Task<List<Place>?> GetFreePlacesAsync(int routeID)
        {
            var route = await _routeRepository.GetRouteByIDAsync(routeID);
            var places = await _placeRepository.GetPlacesByRouteAsync(route);  
            var freePlaces = new List<Place>();
            foreach (var place in places)
            {
                if (await IsFreePlace(route.RouteID, place.PlaceID))
                {
                    freePlaces.Add(place);
                }
            }
            return freePlaces;
        }

        public async Task<bool> IsFreePlace(int routeID, int placeID)
        {
            var route = await _routeRepository.GetRouteByIDAsync(routeID);
            if (route == null) return false;

            var place = await _placeRepository.GetPlaceByIDAsync(placeID);
            if (place == null) return false;

            var places = await _placeRepository.GetPlacesByRouteAsync(route);
            if (places == null || !places.Any(p => p.PlaceID == place.PlaceID)) return false;

            return await _placeRepository.GetOccupiedPlaceByPlaceAsync(place) == null;
        }

        public async Task<Invoice?> BookTicketsAsync(BookingRequestDTO requestDTO)
        {
            if (!IsValidRequest(requestDTO)) return null;

            var route = await _routeRepository.GetRouteByIDAsync(requestDTO.RouteID);
            if (route == null) return null;

            var freePlaces = await GetFreePlacesAsync(requestDTO.RouteID);
            if (freePlaces == null || !requestDTO.PlacesID.All(id => freePlaces.Any(fp => fp.PlaceID == id))) return null;

            var invoice = await CreateInvoiceAsync(route.Price * requestDTO.PlacesID.Count, requestDTO.Passengers.First().UserID);

            var tickets = await CreateTicketsAsync(requestDTO, route, invoice, freePlaces);

            return tickets.Any() ? invoice : null;
        }

        private bool IsValidRequest(BookingRequestDTO requestDTO)
        {
            return requestDTO != null && requestDTO.Passengers != null && requestDTO.PlacesID != null &&
                   requestDTO.Passengers.Count == requestDTO.PlacesID.Count;
        }

        private async Task<Invoice> CreateInvoiceAsync(decimal totalCost, int userID)
        {
            var invoice = new Invoice
            {
                Amount = totalCost,
                CreationDatetime = DateTime.Now,
            };
            await _invoiceRepository.CreateInvoiceAsync(invoice);
            return invoice;
        }

        private async Task<List<Ticket>> CreateTicketsAsync(BookingRequestDTO requestDTO, Route route, Invoice invoice, List<Place> freePlaces)
        {
            var tickets = new List<Ticket>();
            for (int i = 0; i < requestDTO.PlacesID.Count; i++)
            {
                var placeID = requestDTO.PlacesID[i];
                var passenger = requestDTO.Passengers[i];

                if (!freePlaces.Any(fp => fp.PlaceID == placeID)) continue;

                var ticket = await CreateTicketAsync(passenger, route, invoice, route.DepartureDatetime);
                await MarkPlaceAsOccupiedAsync(placeID, ticket);
                tickets.Add(ticket);
            }
            return tickets;
        }

        private async Task<Ticket> CreateTicketAsync(Passenger passenger, Route route, Invoice invoice, DateTime departureDateTime)
        {   
            var ticket = new Ticket
            {
                    PassengerID = passenger.PassengerID,
                    RouteID = route.RouteID,
                    InvoiceID = invoice.InvoiceID,
                    DatetimeDeparture = departureDateTime,
            };
            await _ticketRepository.CreateTicketAsync(ticket);
            return ticket;
        }
        
        private async Task MarkPlaceAsOccupiedAsync(int placeID, Ticket ticket)
        {
            var occupiedPlace = new OccupiedPlace
            {
                PlaceID = placeID,
                TicketID = ticket.TicketID,
            };
            await _placeRepository.CreateOccupiedPlaceAsync(occupiedPlace);
        }
    }
}
