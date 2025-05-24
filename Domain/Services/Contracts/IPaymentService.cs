using BusStationPlatform.Domain.Entities;

namespace BusStationPlatform.Domain.Services.Contracts
{
    /// <summary>
    /// Интерфейс для обработки платежей.
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Асинхронно выполняет платеж с использованием кредитной карты.
        /// </summary>
        /// <param name="invoiceId">Идентификатор счета для платежа.</param>
        /// <param name="token">Токен отмены для управления асинхронной операцией.</param>
        /// <returns>Кортеж, содержащий сообщение об ошибке и объект платежа.</returns>
        public Task<(string? error, Payment? payment)> PayByCreditCardAsync(int invoiceId, CancellationToken token);

        /// <summary>
        /// Асинхронно выполняет платеж с использованием системы быстрых платежей.
        /// </summary>
        /// <param name="invoiceId">Идентификатор счета для платежа.</param>
        /// <param name="token">Токен отмены для управления асинхронной операцией.</param>
        /// <returns>Кортеж, содержащий сообщение об ошибке и объект платежа.</returns>
        public Task<(string? error, Payment? payment)> PayBySystemFastPaymentsAsync(int invoiceId, CancellationToken token);

        /// <summary>
        /// Асинхронно выполняет платеж с использованием электронного кошелька.
        /// </summary>
        /// <param name="invoiceId">Идентификатор счета для платежа.</param>
        /// <param name="token">Токен отмены для управления асинхронной операцией.</param>
        /// <returns>Кортеж, содержащий сообщение об ошибке и объект платежа.</returns>
        public Task<(string? error, Payment? payment)> PayByElectronicWalletAsync(int invoiceId, CancellationToken token);
    }
}
