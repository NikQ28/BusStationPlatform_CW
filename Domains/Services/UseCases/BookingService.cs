using BusStationPlatform.Domains.ValueObjects;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;
using Route = BusStationPlatform.Domains.Entities.Route;
using BusStationPlatform.Domains.Services.Contracts.Repositories;


namespace BusStationPlatform.Domains.Services.UseCases
{
    public class BookingService(ISeatRepository placeRepository, IRouteRepository routeRepository, 
        ITicketRepository ticketRepository, IInvoiceRepository invoiceRepository) : IBookingService
    {
        public async Task<(string? error, List<Seat>? result)> GetFreeSeatsAsync(int id, CancellationToken token)
        {
            var route = await routeRepository.GetRouteByIdAsync(id, token);
            if (route == null) return ("Маршрут не найден", null);

            var places = await placeRepository.GetSeatsByRouteAsync(route, token);
            if (places == null) return ("Маршрут не найден", null);

            var freePlaces = new List<Seat>();
            foreach (var place in places)
                if (await placeRepository.GetOccupiedSeatBySeatAsync(place, token) == null) 
                    freePlaces.Add(place);
            return (null, freePlaces);
        }

        public async Task<(string? error, Invoice? result)> BookingTicketsAsync(BookingRequest bookingRequest, CancellationToken token)
        {
            var route = await routeRepository.GetRouteByIdAsync(bookingRequest.RouteId, token);
            if (route == null) return ("Маршрут не найден", null);

            var invoice = new Invoice {
                Amount = route.Price * bookingRequest.SeatsIds.Count,
                CreationDatetime = DateTime.Now,
            };
            await invoiceRepository.CreateInvoiceAsync(invoice, token);

            var (error, tickets) = await CreateTicketsAsync(bookingRequest, invoice, route, token);
            return (tickets?.Count < 0) ? (null, invoice) : (error, null);

        }

        private async Task<(string? error, List<Ticket>? result)> CreateTicketsAsync(BookingRequest bookingRequest, Invoice invoice, Route route, CancellationToken token)
        {
            var (error, freeSeats) = await GetFreeSeatsAsync(bookingRequest.RouteId, token);
            if (freeSeats == null) return (error, null);

            var tickets = new List<Ticket>();
            for (int i = 0; i < bookingRequest.SeatsIds.Count; i++)
            {
                var seatId = bookingRequest.SeatsIds[i];
                var passenger = bookingRequest.Passengers[i];
                if (!freeSeats.Any(fp => fp.SeatId == seatId)) continue;

                var ticket = new Ticket
                {
                    PassengerId = passenger.PassengerId,
                    RouteId = route.RouteId,
                    InvoiceId = invoice.InvoiceId,
                    DatetimeDeparture = route.DepartureDatetime
                };
                await ticketRepository.CreateTicketAsync(ticket, token);

                await placeRepository.CreateOccupiedSeatAsync(new OccupiedSeat {SeatId = seatId, TicketId = ticket.TicketId}, token);
                tickets.Add(ticket);
            }
            return (error, tickets);
        }
    }
}
