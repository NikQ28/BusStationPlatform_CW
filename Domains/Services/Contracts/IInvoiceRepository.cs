using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.Services.Contracts
{
    public interface IInvoiceRepository
    {
        /// <summary>
        /// Получает счет по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор счета.</param>
        /// <returns>Счет или null, если не найден.</returns>
        public Task<Invoice?> GetInvoiceByIDAsync(int id);

        /// <summary>
        /// Создаёт новый счёт.
        /// </summary>
        /// <param name="newInvoice">Новый счёт.</param>
        /// <returns>Счет или null, если не найден.</returns>
        public Task<Invoice?> CreateInvoiceAsync(Invoice newInvoice);
    }
}
