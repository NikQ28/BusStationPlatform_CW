namespace BusStationPlatform.Domains.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int UserID { get; set; }
        public int InvoiceID { get; set; }
        public decimal Amount { get; set; }
        public string? Method { get; set; }
        public DateTime PaymentDatetime { get; set; }
    }
}
