using BusStationPlatform.Domains.ValueObjects;
using BusStationPlatform.Domains.Services.Contracts;

using Route = BusStationPlatform.Domains.Entities.Route;
using BusStationPlatform.Domains.Services.Contracts.Repositories;

namespace BusStationPlatform.Domains.Services.UseCases
{
    public class SearchRouteService(IRouteRepository routeRepository) : ISearchRouteService
    {
        public async Task<(string? error, List<Route>? result)> GetRoutesAsync(SearchRouteRequest routeRequest, CancellationToken token)
        {
            var routes = await routeRepository.GetRoutesByPointsDateAsync(routeRequest, token);
            return routes == null ? ("Маршруты не найдены", null) : (null, routes);
        }
    }
}
