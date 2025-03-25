using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;
using BusStationPlatform.Storage;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Domains.Services
{
    public class InvoiceService(ApplicationContext _context) : IInvoiceService
    {
        public async Task<Invoice> GetInvoiceByIDAsync(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return null;
            }
            return invoice;
        }

        public async Task<Invoice> CreateInvoiceAsync(InvoiceDTO invoiceDTO)
        {
            var invoice = invoiceDTO.ToInvoice();
            await _context.Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice> UpdateInvoiceAsync(Invoice updatedInvoice)
        {
            var invoice = _context.Invoices.Find(updatedInvoice.InvoiceID);
            if (invoice == null)
                return null;
            _context.Invoices.Update(updatedInvoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice != null)
            {
                _context.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
