using Microsoft.EntityFrameworkCore;

using BusStationPlatform.Domain.ValueObjects;
using Route = BusStationPlatform.Domain.Entities.Route;
using BusStationPlatform.Domain.Services.Contracts.Repositories;

namespace BusStationPlatform.Storage
{
    public class RouteRepository(BusStationPlatformContext context) : IRouteRepository
    {
        public async Task<Route?> GetRouteByIdAsync(int id, CancellationToken token) =>
            await context.Route.FindAsync([id], token);

        public async Task<List<Route>?> GetRoutesByPointsDateAsync(SearchRouteRequest routeRequest, CancellationToken token)
        {
            var routesIds = await GetRoutesIdsByPointsDateAsync(routeRequest, token);
            if (routesIds == null) return null;
            return await context.Route.Where(route => routesIds.Contains(route.RouteId)).ToListAsync(token);
        }

        public async Task<List<int>?> GetRoutesIdsByPointsDateAsync(SearchRouteRequest routeRequest, CancellationToken token) =>
            await context.Route
                .Where(r => r.DeparturePoint == routeRequest.DeparturePoint 
                    && r.ArrivalPoint == routeRequest.ArrivalPoint 
                    && DateOnly.FromDateTime(r.DepartureDatetime) == routeRequest.DepartureDatetime)
                .Select(r => r.RouteId)
                .ToListAsync(token);
    }
}
