using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;
using BusStationPlatform.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using System.ComponentModel;

namespace BusStationPlatform.Domains.Services
{
    public class PlaceService(ApplicationContext _context) : IPlaceService
    {
        public async Task<Place> GetPlaceByIDAsync(int id)
        {
            var place = await _context.Places.FindAsync(id);
            if (place == null)
                return null;
            return place;
        }

        public async Task<Place> CreatePlaceAsync(PlaceDTO placeDTO)
        {
            var place = placeDTO.ToPlace();
            _context.Places.Add(place);
            await _context.SaveChangesAsync();
            return place;
        }

        public async Task<Place> UpdatePlaceAsync(Place updatedPlace)
        {
            var place = await _context.Places.FindAsync(updatedPlace.PlaceID);
            if (place == null)
                return null;
            _context.Places.Update(place);
            await _context.SaveChangesAsync();
            return updatedPlace;
        }

        public async Task DeletePlaceAsync(int id)
        {
            var place = await _context.Places.FindAsync(id);
            if (place != null)
            {
                _context.Places.Remove(place);
                await _context.SaveChangesAsync();
            }
        }
    }
}
