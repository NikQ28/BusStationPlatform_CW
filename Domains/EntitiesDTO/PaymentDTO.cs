using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.EntitiesDTO
{
    public class PaymentDTO
    {
        public int UserID { get; set; }
        public int InvoiceID { get; set; }
        public decimal Amount { get; set; }
        public string? Method { get; set; }
        public DateTime PaymentDatetime { get; set; }

        public Payment ToPayment()
        {
            return new Payment
            {
                UserID = UserID,
                InvoiceID = InvoiceID,
                Amount = Amount,
                Method = Method,
                PaymentDatetime = PaymentDatetime
            };
        }

        public PaymentDTO FromPAyment(Payment payment) 
        {
            return new PaymentDTO
            {
                UserID = payment.UserID,
                InvoiceID = payment.InvoiceID,
                Amount = payment.Amount,
                Method = payment.Method,
                PaymentDatetime = payment.PaymentDatetime,
            };
        }
    }
}
