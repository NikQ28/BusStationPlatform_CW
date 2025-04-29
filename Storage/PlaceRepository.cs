using BusStationPlatform.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using BusStationPlatform.Domains.Services.Contracts;
using Route = BusStationPlatform.Domains.Entities.Route;
using System.Reflection.Metadata.Ecma335;

namespace BusStationPlatform.Storage
{
    public class PlaceRepository(BusStationPlatformContext _context) : IPlaceRepository
    {
        public async Task<Place?> GetPlaceByIDAsync(int placeID) =>
            await _context.Place.FindAsync(placeID);

        public async Task<List<int>?> GetPlacesIDByRouteAsync(Route route) =>
            await _context.Place
                .Where(p => p.RouteID == route.RouteID)
                .Select(p => p.PlaceID)
                .ToListAsync();

        public async Task<List<Place>?> GetPlacesByRouteAsync(Route route)
        {
            var placesID = await GetPlacesIDByRouteAsync(route);
            return await _context.Place.Where(place => placesID.Contains(place.PlaceID)).ToListAsync();
        }

        public async Task<OccupiedPlace?> CreateOccupiedPlaceAsync(OccupiedPlace newOccupiedPlace)
        {
            _context.OccupiedPlace.Add(newOccupiedPlace);
            await _context.SaveChangesAsync();
            return newOccupiedPlace;
        }

        public async Task<int?> DeleteOccupiedPlaceAsync(int id)
        {
            var occupiedPlace = await _context.OccupiedPlace.FindAsync(id);
            if (occupiedPlace != null)
            {
                _context.Remove(occupiedPlace);
                await _context.SaveChangesAsync();
                return id;
            }
            return null;
        }

        public async Task<OccupiedPlace?> GetOccupiedPlaceByTicketAsync(Ticket ticket) =>
            await _context.OccupiedPlace.FirstOrDefaultAsync(occupiedPlace => occupiedPlace.TicketID == ticket.TicketID);

        public async Task<OccupiedPlace?> GetOccupiedPlaceByPlaceAsync(Place place) =>
            await _context.OccupiedPlace.FirstOrDefaultAsync(occupiedPlace => occupiedPlace.PlaceID == place.PlaceID);
    }
}
