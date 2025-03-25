using BusStationPlatform.Storage;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;
using Microsoft.EntityFrameworkCore;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services
{
    public class RouteService(ApplicationContext _context) : IRouteService
    {
        public async Task<Route> GetRouteByIDAsync(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null)
                return null;
            return route;
        }

        public async Task<Route> CreateRouteAsync(RouteDTO routeDTO)
        {
            var route = routeDTO.ToRoute();
            await _context.Routes.AddAsync(route);
            await _context.SaveChangesAsync();
            return route;
        }

        public async Task<Route> UpdateRouteAsync(Route updatedRoute)
        {
            var route = await _context.Routes.FindAsync(updatedRoute.RouteID);
            if (route == null)
                return null;
            _context.Update(updatedRoute);
            await _context.SaveChangesAsync();
            return updatedRoute;
        }
        
        public async Task DeleteRouteAsync(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route != null)
            {
                _context.Routes.Remove(route);
                await _context.SaveChangesAsync();
            }
        }
    }
}
