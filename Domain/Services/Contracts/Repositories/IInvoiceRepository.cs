using BusStationPlatform.Domain.Entities;

namespace BusStationPlatform.Domain.Services.Contracts.Repositories
{
    public interface IInvoiceRepository
    {
        public Task<Invoice?> GetInvoiceByIdAsync(int id, CancellationToken token);

        public Task<Invoice?> CreateInvoiceAsync(Invoice newInvoice, CancellationToken token);

        public Task<Invoice?> UpdateInvoiceAsync(Invoice updatedInvoice, CancellationToken token);

        public Task<List<Invoice>?> GetExpiredInvoicesAsync(CancellationToken token);
    }
}
