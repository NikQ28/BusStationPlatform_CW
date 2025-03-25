using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.Services
{
    public interface IPassengerService
    {
        public Task<Passenger> GetPassengerByIDAsync(int id);
        public Task<Passenger> CreatePassengerAsync(Passenger passenger);
        public Task<Passenger> UpdatePassengerAsync(Passenger passenger);
        public Task DeletePassengerAsync(int id);
    }
}
