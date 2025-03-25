using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services
{
    public interface IRouteService
    {
        public Task<Route> GetRouteByIDAsync(int id);
        public Task<Route> CreateRouteAsync(RouteDTO routeDTO);
        public Task<Route> UpdateRouteAsync(Route updatedRoute);
        public Task DeleteRouteAsync(int id);
        
    }
}
