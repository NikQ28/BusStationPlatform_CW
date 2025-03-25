using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;
using BusStationPlatform.Storage;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Domains.Services
{
    public class OccupiedPlaceService(ApplicationContext _context) : IOccupiedPlaceService
    {
        public async Task<OccupiedPlace> GetOccupiedPlaceByIDAsync(int id)
        {
            var occupiedPlace = await _context.OccupiedPlaces.FindAsync(id);
            if (occupiedPlace == null)
                return null;
            return occupiedPlace;
        }

        public async Task<OccupiedPlace> CreateOccupiedPlaceAsync(OccupiedPlaceDTO occupiedPlaceDTO)
        {
            var occupiedPlace = occupiedPlaceDTO.ToOccupiedPlace();
            _context.OccupiedPlaces.Add(occupiedPlace);
            await _context.SaveChangesAsync();
            return occupiedPlace;
        }

        public async Task<OccupiedPlace> UpdateOccupiedPlaceAsync(OccupiedPlace updatedOccupiedPlace)
        {
            var occupiedPlace = await _context.OccupiedPlaces.FindAsync(updatedOccupiedPlace.OccupiedPlaceID);
            if (occupiedPlace == null)
                return null;
            _context.OccupiedPlaces.Update(occupiedPlace);
            await _context.SaveChangesAsync();
            return updatedOccupiedPlace;
        }

        public async Task DeleteOccupiedPlaceAsync(int id)
        {
            var occupiedPlace = await _context.OccupiedPlaces.FindAsync(id);
            if (occupiedPlace != null)
            {
                _context.OccupiedPlaces.Remove(occupiedPlace);
                await _context.SaveChangesAsync();
            }
        } 
    }
}
