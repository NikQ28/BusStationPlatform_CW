using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.EntitiesDTO
{
    public class InvoiceDTO
    {
        public decimal Amount { get; set; }
        public DateTime CreationDatetime { get; set; }

        public Invoice ToInvoice()
        {
            return new Invoice
            {
                Amount = Amount,
                CreationDatetime = CreationDatetime
            };
        }

        public InvoiceDTO FromInvoice(Invoice invoice)
        {
            return new InvoiceDTO
            {
                Amount = invoice.Amount,
                CreationDatetime = invoice.CreationDatetime
            };
        }
    }
}
