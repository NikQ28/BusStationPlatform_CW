namespace BusStationPlatform.Domains.Entities
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int PassengerID { get; set; }
        public int RouteID { get; set; }
        public int InvoiceID { get; set; }
        public DateTime DatetimeDeparture { get; set; }
    }
}
