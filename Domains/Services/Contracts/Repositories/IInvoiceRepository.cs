using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.Services.Contracts.Repositories
{
    public interface IInvoiceRepository
    {
        public Task<Invoice?> GetInvoiceByIdAsync(int id, CancellationToken token);

        public Task<Invoice?> CreateInvoiceAsync(Invoice newInvoice, CancellationToken token);
    }
}
