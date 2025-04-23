using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.Services.Contracts
{
    public interface IPaymentRepository
    {
        /// <summary>
        /// Получает список платежей по пользователю.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Список платежей или null, если не найдено.</returns>
        public Task<List<Payment>?> GetPaymentsByUserAsync(User user);

        /// <summary>
        /// Получает платеж по счету.
        /// </summary>
        /// <param name="invoice">Счет.</param>
        /// <returns>Платеж или null, если не найден.</returns>
        public Task<Payment?> GetPaymentByInvoiceAsync(Invoice invoice);

        /// <summary>
        /// Создает новый платеж.
        /// </summary>
        /// <param name="newPayment">Новый платеж.</param>
        public Task<Payment?> CreatePaymentAsync(Payment newPayment);
    }
}
