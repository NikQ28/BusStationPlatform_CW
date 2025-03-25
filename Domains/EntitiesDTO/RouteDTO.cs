using BusStationPlatform.Domains.Entities;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.EntitiesDTO
{
    public class RouteDTO
    {
        public string? DeparturePoint { get; set; }
        public string? ArrivalPoint { get; set; }
        public DateTime? DepartureDatetime { get; set; }
        public decimal Price { get; set; }

        public Route ToRoute()
        {
            return new Route
            {
                DeparturePoint = DeparturePoint,
                ArrivalPoint = ArrivalPoint,
                DepartureDatetime = DepartureDatetime,
                Price = Price
            };
        }

        public static RouteDTO FromRoute(Route route) 
        {
            return new RouteDTO
            {
                DeparturePoint = route.DeparturePoint,
                ArrivalPoint = route.ArrivalPoint,
                DepartureDatetime = route.DepartureDatetime,
                Price = route.Price
            };
        }
    }
}
