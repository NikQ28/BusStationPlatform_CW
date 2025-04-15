namespace BusStationPlatform.Domains.DTO
{
    public class RouteDTO
    {
        public required string DeparturePoint { get; set; }
        public required string ArrivalPoint { get; set; }
        public required DateTime DepartureDateTime { get; set; }
    }
}
