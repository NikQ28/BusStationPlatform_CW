using Microsoft.EntityFrameworkCore;

using BusStationPlatform.Domain.Entities;
using BusStationPlatform.Domain.Services.Contracts.Repositories;

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

        public async Task<Invoice?> UpdateInvoiceAsync(Invoice updatedInvoice, CancellationToken token)
        {
            var invoice = await context.Invoice.FindAsync([updatedInvoice.InvoiceId], token);
            if (invoice == null)
                return null;
            invoice.IsExpired = updatedInvoice.IsExpired;
            context.Update(invoice);
            await context.SaveChangesAsync(token);
            return updatedInvoice;
        }

        public async Task<List<Invoice>?> GetExpiredInvoicesAsync(CancellationToken token) =>
            await context.Invoice.Where(invoice => !invoice.IsPaid
                && !invoice.IsExpired 
                && invoice.CreationDatetime < DateTime.Now.AddMinutes(-10))
                .ToListAsync(token);
    }
}
