using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.Services.Contracts.Repositories
{
    public interface IPassengerRepository
    {
        public Task<Passenger?> GetPassengerByIdAsync(int id, CancellationToken token);

        public Task<Passenger?> GetPassengerByPassportAsync(string passport, CancellationToken token);

        public Task<Passenger?> CreatePassengerAsync(Passenger newPassenger, CancellationToken token);

        public Task<Passenger?> UpdatePassengerAsync(Passenger updatedPassenger, CancellationToken token);

        public Task<int?> DeletePassengerAsync(int id, CancellationToken token);

        public Task<List<Passenger>?> GetPassengersByUserAsync(User user, CancellationToken token);
    }
}
