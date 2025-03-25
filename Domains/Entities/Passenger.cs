namespace BusStationPlatform.Domains.Entities
{
    public class Passenger
    {
        public int PassengerID { get; set; }
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Passport { get; set; }
    }
}
