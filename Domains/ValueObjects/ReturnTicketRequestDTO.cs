namespace BusStationPlatform.Domains.ValueObjects
{
    public class ReturnTicketRequestDTO
    {
        public required int TicketID { get; set; }

        public required string Surname { get; set; }
    }
}
