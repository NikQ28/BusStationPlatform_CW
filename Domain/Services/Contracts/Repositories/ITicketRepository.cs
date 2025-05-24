using BusStationPlatform.Domain.Entities;
using Route = BusStationPlatform.Domain.Entities.Route;

namespace BusStationPlatform.Domain.Services.Contracts.Repositories
{
    public interface ITicketRepository
    {
        public Task<Ticket?> GetTicketByIdAsync(int id, CancellationToken token);

        public Task<Ticket?> CreateTicketAsync(Ticket newTicket, CancellationToken token);

        public Task<int?> DeleteTicketAsync(int id, CancellationToken token);

        public Task<List<Ticket>?> GetTicketsByPassengerAsync(Passenger passenger, CancellationToken token);

        public Task<List<Ticket>?> GetTicketsByRouteAsync(Route route, CancellationToken token);

        public Task<List<Ticket>?> GetTicketsByInvoiceAsync(Invoice invoice, CancellationToken token);
    }
}
