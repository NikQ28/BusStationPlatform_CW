using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;

namespace BusStationPlatform.Domains.Services
{
    public interface IInvoiceService
    {
        public Task<Invoice> GetInvoiceByIDAsync(int id);
        public Task<Invoice> CreateInvoiceAsync(InvoiceDTO invoiceDTO);
        public Task<Invoice> UpdateInvoiceAsync(Invoice updatedInvoice);
        public Task DeleteInvoiceAsync(int id);
    }
}
