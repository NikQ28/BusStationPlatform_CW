using BusStationPlatform.Domain.ValueObjects;
using Route = BusStationPlatform.Domain.Entities.Route;

namespace BusStationPlatform.Domain.Services.Contracts.Repositories
{
    public interface IRouteRepository
    {
        public Task<Route?> GetRouteByIdAsync(int id, CancellationToken token);

        public Task<List<Route>?> GetRoutesByPointsDateAsync(SearchRouteRequest routeRequest, CancellationToken token);
    }
}
