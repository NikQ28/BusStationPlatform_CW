namespace BusStationPlatform.Domains.Entities
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDatetime { get; set; }
    }
}
