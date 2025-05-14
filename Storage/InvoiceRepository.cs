using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Storage
{
    public class InvoiceRepository(BusStationPlatformContext context) : IInvoiceRepository
    {
        public async Task<Invoice?> GetInvoiceByIdAsync(int id, CancellationToken token) =>
            await context.Invoice.FindAsync([id], token);

        public async Task<Invoice?> CreateInvoiceAsync(Invoice invoice, CancellationToken token)
        {
            context.Add(invoice);
            await context.SaveChangesAsync(token);
            return invoice;
        }
    }
}
