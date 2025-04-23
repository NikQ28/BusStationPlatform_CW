using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Storage
{
    public class TicketRepository(BusStationPlatformContext _context) : ITicketRepository
    {
        public async Task<Ticket?> GetTicketByIDAsync(int id) =>
            await _context.Ticket.FindAsync(id);

        public async Task<Ticket?> CreateTicketAsync(Ticket newTicket)
        {
            _context.Ticket.Add(newTicket);
            await _context.SaveChangesAsync();
            return newTicket;
        }

        public async Task<int?> DeleteTicketAsync(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
                await _context.SaveChangesAsync();
                return id;
            }
            return null;
        }

        public async Task<List<Ticket>?> GetTicketsByPassengerAsync(Passenger passenger)
        {
            var ticketsID = await GetTicketsIDByPassengerAsync(passenger);
            return await _context.Ticket.Where(ticket => ticketsID.Contains(ticket.TicketID)).ToListAsync();
        }

        public async Task<List<int>?> GetTicketsIDByPassengerAsync(Passenger passenger) =>
            await _context.Ticket
                .Where(p => p.PassengerID == passenger.PassengerID)
                .Select(p => p.TicketID)
                .ToListAsync();

        public async Task<List<Ticket>?> GetTicketsByRouteAsync(Route route)
        {
            var ticketsID = await GetTicketsIDByRouteAsync(route);
            return await _context.Ticket.Where(ticket => ticketsID.Contains(ticket.TicketID)).ToListAsync();
        }

        public async Task<List<int>?> GetTicketsIDByRouteAsync(Route route) =>
            await _context.Ticket
            .Where(t => t.RouteID == route.RouteID)
            .Select(t => t.TicketID)
            .ToListAsync();

        public async Task<List<Ticket>?> GetTicketsByInvoiceAsync(Invoice invoice)
        {
            var ticketsID = await GetTicketsIDByInvoiceAsync(invoice);
            return await _context.Ticket.Where(ticket => ticketsID.Contains(ticket.TicketID)).ToListAsync();
        }

        public async Task<List<int>?> GetTicketsIDByInvoiceAsync(Invoice invoice) =>
            await _context.Ticket
                .Where(ticket => ticket.InvoiceID == invoice.InvoiceID)
                .Select(ticket => ticket.TicketID)
                .ToListAsync();
    }
}
