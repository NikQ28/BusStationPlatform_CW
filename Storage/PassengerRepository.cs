using Microsoft.EntityFrameworkCore;

using BusStationPlatform.Domain.Entities;
using BusStationPlatform.Domain.Services.Contracts.Repositories;

namespace BusStationPlatform.Storage
{
    public class PassengerRepository(BusStationPlatformContext context) : IPassengerRepository
    {
        public async Task<Passenger?> GetPassengerByIdAsync(int id, CancellationToken token) =>
            await context.Passenger.FindAsync([id], token);

        public async Task<Passenger?> GetPassengerByPassportAsync(string passport, CancellationToken token) =>
            await context.Passenger.FirstOrDefaultAsync(passenger => passenger.Passport == passport, token);

        public async Task<Passenger?> CreatePassengerAsync(Passenger newPassenger, CancellationToken token)
        {
            context.Passenger.Add(newPassenger);
            await context.SaveChangesAsync(token);
            return newPassenger;
        }

        public async Task<Passenger?> UpdatePassengerAsync(Passenger updatedPassenger, CancellationToken token)
        {
            var passenger = await context.Passenger.FindAsync(updatedPassenger.PassengerId, token);
            if (passenger == null)
                return null;
            context.Update(updatedPassenger);
            await context.SaveChangesAsync(token);
            return updatedPassenger;
        }

        public async Task<int?> DeletePassengerAsync(int id, CancellationToken token)
        {
            var passenger = await context.Passenger.FindAsync(id, token);
            if (passenger != null)
            {
                context.Passenger.Remove(passenger);
                await context.SaveChangesAsync(token);
                return id;
            }
            return null;
        }

        public async Task<List<Passenger>?> GetPassengersByUserAsync(User user, CancellationToken token)
        {
            var passengersIds = await GetPassengersIdsByUserAsync(user, token);
            if (passengersIds == null) return null;
            return await context.Passenger.Where(passenger => passengersIds.Contains(passenger.PassengerId)).ToListAsync(token);
        }

        public async Task<List<int>?> GetPassengersIdsByUserAsync(User user, CancellationToken token) =>
            await context.Passenger
                .Where(u => u.UserId == user.UserId)
                .Select(u => u.PassengerId)
                .ToListAsync(token);
    }
}
