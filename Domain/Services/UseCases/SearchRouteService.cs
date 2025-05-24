using BusStationPlatform.Domain.ValueObjects;
using BusStationPlatform.Domain.Services.Contracts;

using Route = BusStationPlatform.Domain.Entities.Route;
using BusStationPlatform.Domain.Services.Contracts.Repositories;

namespace BusStationPlatform.Domain.Services.UseCases
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
