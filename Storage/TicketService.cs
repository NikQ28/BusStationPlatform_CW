using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;
using BusStationPlatform.Storage;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Domains.Services
{
    public class TicketService(ApplicationContext _context) : ITicketService
    {
        public async Task<Ticket> GetTicketByIDAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
                return null;
            return ticket;
        }

        public async Task<Ticket> CreateTicketAsync(TicketDTO ticketDTO)
        {
            var ticket = ticketDTO.ToTicket();
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> UpdateTicketAsync(Ticket updatedTicket)
        {
            var ticket = await _context.Tickets.FindAsync(updatedTicket.TicketID);
            if (ticket == null)
                return null;
            _context.Update(updatedTicket);
            await _context.SaveChangesAsync();
            return updatedTicket;
        }

        public async Task DeleteTicketAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }
    }
}

