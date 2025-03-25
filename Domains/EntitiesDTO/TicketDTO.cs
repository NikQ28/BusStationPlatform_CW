using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.EntitiesDTO
{
    public class TicketDTO
    {
        public int PassengerID { get; set; }
        public int RouteID { get; set; }
        public int InvoiceID { get; set; }
        public DateTime DatetimeDeparture { get; set; }


        public Ticket ToTicket()
        {
            return new Ticket
            {
                PassengerID = PassengerID,
                RouteID = RouteID,
                InvoiceID = InvoiceID,
                DatetimeDeparture = DatetimeDeparture
            };
        }

        public static TicketDTO FromTicket(Ticket ticket)
        {
            return new TicketDTO
            {
                PassengerID = ticket.PassengerID,
                RouteID = ticket.RouteID,
                InvoiceID = ticket.InvoiceID,
                DatetimeDeparture = ticket.DatetimeDeparture
            };
        }
    }
}
