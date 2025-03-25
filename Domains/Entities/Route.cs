namespace BusStationPlatform.Domains.Entities
{
    public class Route
    {
        public int RouteID { get; set; }
        public string? DeparturePoint { get; set; }
        public string? ArrivalPoint { get; set; }
        public DateTime? DepartureDatetime { get; set; }
        public decimal Price { get; set; }
    }
}
