using BusStationPlatform.Domains.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services.Contracts.Repositories
{
    public interface IRouteRepository
    {
        public Task<Route?> GetRouteByIdAsync(int id, CancellationToken token);

        public Task<List<Route>?> GetRoutesByPointsDateAsync(SearchRouteRequest routeRequest, CancellationToken token);
    }
}
