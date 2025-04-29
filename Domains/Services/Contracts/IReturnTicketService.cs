using BusStationPlatform.Domains.ValueObjects;

namespace BusStationPlatform.Domains.Services.Contracts
{
    public interface IReturnTicketService
    {
        public Task<int?> ReturnTicketAsync(ReturnTicketRequestDTO returnTicketRequestDTO);
    }
}
