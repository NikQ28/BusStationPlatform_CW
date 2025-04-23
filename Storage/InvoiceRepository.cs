using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Storage
{
    public class InvoiceRepository(BusStationPlatformContext _context) : IInvoiceRepository
    {
        public async Task<Invoice?> GetInvoiceByIDAsync(int id) =>
            await _context.Invoice.FindAsync(id);

        public async Task<Invoice?> CreateInvoiceAsync(Invoice invoice)
        {
            _context.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }
    }
}
