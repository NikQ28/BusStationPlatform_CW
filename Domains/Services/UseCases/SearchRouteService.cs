using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Services.Contracts;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services
{
    public class SearchRouteService(IRouteRepository _routeRepository) : ISearchRouteService
    {
        public async Task<List<Route>?> GetRoutesAsync(RouteRequestDTO routeDTO) =>
            await _routeRepository.GetRoutesByPointsDateAsync(routeDTO);
    }
}
