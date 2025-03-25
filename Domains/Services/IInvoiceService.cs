using BusStationPlatform.Storage;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;
using Microsoft.EntityFrameworkCore;

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
