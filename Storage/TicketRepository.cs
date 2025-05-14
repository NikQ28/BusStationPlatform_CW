using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Storage
{
    public class TicketRepository(BusStationPlatformContext context) : ITicketRepository
    {
        public async Task<Ticket?> GetTicketByIdAsync(int id, CancellationToken token) =>
            await context.Ticket.FindAsync([id], token);

        public async Task<Ticket?> CreateTicketAsync(Ticket newTicket, CancellationToken token)
        {
            context.Ticket.Add(newTicket);
            await context.SaveChangesAsync(token);
            return newTicket;
        }

        public async Task<int?> DeleteTicketAsync(int id, CancellationToken token)
        {
            var ticket = await context.Ticket.FindAsync([id], token);
            if (ticket != null)
            {
                context.Ticket.Remove(ticket);
                await context.SaveChangesAsync(token);
                return id;
            }
            return null;
        }

        public async Task<List<Ticket>?> GetTicketsByPassengerAsync(Passenger passenger, CancellationToken token)
        {
            var ticketsIds = await GetTicketsIdsByPassengerAsync(passenger, token);
            if (ticketsIds == null) return null;
            return await context.Ticket.Where(ticket => ticketsIds.Contains(ticket.TicketId)).ToListAsync(token);
        }

        public async Task<List<int>?> GetTicketsIdsByPassengerAsync(Passenger passenger, CancellationToken token) =>
            await context.Ticket
                .Where(p => p.PassengerId == passenger.PassengerId)
                .Select(p => p.TicketId)
                .ToListAsync(token);

        public async Task<List<Ticket>?> GetTicketsByRouteAsync(Route route, CancellationToken token)
        {
            var ticketsIds = await GetTicketsIdsByRouteAsync(route, token);
            if (ticketsIds == null) return null;
            return await context.Ticket.Where(ticket => ticketsIds.Contains(ticket.TicketId)).ToListAsync(token);
        }

        public async Task<List<int>?> GetTicketsIdsByRouteAsync(Route route, CancellationToken token) =>
            await context.Ticket
            .Where(t => t.RouteId == route.RouteId)
            .Select(t => t.TicketId)
            .ToListAsync(token);

        public async Task<List<Ticket>?> GetTicketsByInvoiceAsync(Invoice invoice, CancellationToken token)
        {
            var ticketsIds = await GetTicketsIdsByInvoiceAsync(invoice, token);
            if (ticketsIds == null) return null;
            return await context.Ticket.Where(ticket => ticketsIds.Contains(ticket.TicketId)).ToListAsync(token);
        }

        public async Task<List<int>?> GetTicketsIdsByInvoiceAsync(Invoice invoice, CancellationToken token) =>
            await context.Ticket
                .Where(ticket => ticket.InvoiceId == invoice.InvoiceId)
                .Select(ticket => ticket.TicketId)
                .ToListAsync(token);
    }
}
