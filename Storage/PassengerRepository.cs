using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Storage
{
    public class PassengerRepository(BusStationPlatformContext _context) : IPassengerRepository
    {
        public async Task<Passenger?> GetPassengerByIDAsync(int id) =>
            await _context.Passenger.FindAsync(id);

        public async Task<Passenger?> GetPassengerByPassportAsync(string passport) =>
            await _context.Passenger.FirstOrDefaultAsync(passenger => passenger.Passport == passport);

        public async Task<Passenger?> CreatePassengerAsync(Passenger newPassenger)
        {
            _context.Passenger.Add(newPassenger);
            await _context.SaveChangesAsync();
            return newPassenger;
        }

        public async Task<Passenger?> UpdatePassengerAsync(Passenger updatedPassenger)
        {
            var passenger = await _context.Passenger.FindAsync(updatedPassenger.PassengerID);
            if (passenger == null)
                return null;
            _context.Update(updatedPassenger);
            await _context.SaveChangesAsync();
            return updatedPassenger;
        }

        public async Task<int?> DeletePassengerAsync(int id)
        {
            var passenger = await _context.Passenger.FindAsync(id);
            if (passenger != null)
            {
                _context.Passenger.Remove(passenger);
                await _context.SaveChangesAsync();
                return id;
            }
            return null;
        }

        public async Task<List<Passenger>?> GetPassengersByUserAsync(User user)
        {
            var passengersID = await GetPassengersIDByUserAsync(user);
            return await _context.Passenger.Where(passenger => passengersID.Contains(passenger.PassengerID)).ToListAsync();
        }

        public async Task<List<int>?> GetPassengersIDByUserAsync(User user) =>
            await _context.Passenger
                .Where(u => u.UserID == user.UserID)
                .Select(u => u.PassengerID)
                .ToListAsync();
    }
}
