using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Storage
{
    public class RouteRepository(BusStationPlatformContext _context) : IRouteRepository
    {
        public async Task<Route?> GetRouteByIDAsync(int id) =>
            await _context.Route.FindAsync(id);

        public async Task<List<Route>?> GetRoutesByPointsDateAsync(RouteRequestDTO routeDTO)
        {
            var routesID = await GetRoutesIDByPointsDateAsync(routeDTO);
            return await _context.Route.Where(route => routesID.Contains(route.RouteID)).ToListAsync();
        }

        public async Task<List<int>?> GetRoutesIDByPointsDateAsync(RouteRequestDTO routeDTO) =>
            await _context.Route
                .Where(r => r.DeparturePoint == routeDTO.DeparturePoint && r.ArrivalPoint == routeDTO.ArrivalPoint && DateOnly.FromDateTime(r.DepartureDatetime) == routeDTO.DepartureDateTime)
                .Select(r => r.RouteID)
                .ToListAsync();
    }
}
