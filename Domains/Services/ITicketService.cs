using BusStationPlatform.Storage;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;

namespace BusStationPlatform.Domains.Services
{
    public interface ITicketService
    {
        public Task<Ticket> GetTicketByIDAsync(int id);
        public Task<Ticket> CreateTicketAsync(TicketDTO ticketDTO);
        public Task<Ticket> UpdateTicketAsync(Ticket ticket);
        public Task DeleteTicketAsync(int id);
    }
}
