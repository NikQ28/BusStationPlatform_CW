using BusStationPlatform.Storage;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Domains.Services
{
    public class PassengerService(ApplicationContext _context)
    {
        public async Task<List<Passenger>> GetAllPassengersAsync()
        {
            return await _context.Passengers.ToListAsync();
        }

        public async Task<Passenger> GetPassengerByIDAsync(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger == null)
                return null;
            return passenger;
        }

        public async Task<Passenger> CreatePassengerAsync(PassengerDTO passengerDTO)
        {
            var passenger = passengerDTO.ToPassenger();
            await _context.Passengers.AddAsync(passenger);
            await _context.SaveChangesAsync();
            return passenger;
        }

        public async Task<Passenger> UpdatePassengerAsync(Passenger updatedPassenger)
        {
            var passenger = await _context.Passengers.FindAsync(updatedPassenger.PassengerID);
            if (passenger == null)
                return null;
            _context.Update(updatedPassenger);
            await _context.SaveChangesAsync();
            return updatedPassenger;
        }

        public async Task DeletePassengerAsync(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {   
                _context.Passengers.Remove(passenger);
                await _context.SaveChangesAsync();
            }
        }
    }
}
