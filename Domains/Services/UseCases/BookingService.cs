using System;
using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;

namespace BusStationPlatform.Domains.Services
{
    public class BookingService(IPlaceRepository _placeRepository, IRouteRepository _routeRepository, 
        ITicketRepository _ticketRepository, IInvoiceRepository _invoiceRepository) : IBookingService
    {
        public async Task<List<Place>?> GetFreePlacesAsync(int routeID)
        {
            var route = await _routeRepository.GetRouteByIDAsync(routeID);
            if (route == null) return null;

            var places = await _placeRepository.GetPlacesByRouteAsync(route);
            if (places == null) return null;

            var freePlaces = new List<Place>();
            foreach (var place in places)
            {
                var isFree = await _placeRepository.GetOccupiedPlaceByPlaceAsync(place) == null;
                if (isFree) freePlaces.Add(place);
            }
            return freePlaces;
        }

        public async Task<Invoice?> BookTicketsAsync(BookingRequestDTO requestDTO)
        {
            if (!IsValidRequest(requestDTO)) return null;

            var route = await _routeRepository.GetRouteByIDAsync(requestDTO.RouteID);
            if (route == null) return null;

            var freePlaces = await GetFreePlacesAsync(requestDTO.RouteID);
            if (freePlaces == null || !requestDTO.PlacesID.All(id => freePlaces.Any(fp => fp.PlaceID == id))) return null;

            var invoice = new Invoice {
                Amount = route.Price * requestDTO.PlacesID.Count,
                CreationDatetime = DateTime.Now,
            };
            await _invoiceRepository.CreateInvoiceAsync(invoice);

            var tickets = new List<Ticket>();
            for (int i = 0; i < requestDTO.PlacesID.Count; i++)
            {
                var placeID = requestDTO.PlacesID[i];
                var passenger = requestDTO.Passengers[i];
                if (!freePlaces.Any(fp => fp.PlaceID == placeID)) continue;

                var ticket = new Ticket {
                    PassengerID = passenger.PassengerID,
                    RouteID = route.RouteID,
                    InvoiceID = invoice.InvoiceID,
                    DatetimeDeparture = route.DepartureDatetime,
                };
                await _ticketRepository.CreateTicketAsync(ticket);

                var occupiedPlace = new OccupiedPlace {
                    PlaceID = placeID,
                    TicketID = ticket.TicketID,
                };
                await _placeRepository.CreateOccupiedPlaceAsync(occupiedPlace);
                tickets.Add(ticket);
            }
            return tickets.Any() ? invoice : null;
        }

        private bool IsValidRequest(BookingRequestDTO requestDTO) =>
            requestDTO != null && requestDTO.Passengers != null && requestDTO.PlacesID != null &&
                   requestDTO.Passengers.Count == requestDTO.PlacesID.Count;
    }
}
