using BusStationPlatform.Domain.Entities;

namespace BusStationPlatform.Domain.Services.Contracts
{
    /// <summary>
    /// Интерфейс для отправки билетов.
    /// </summary>
    public interface ISendTicketService
    {
        /// <summary>
        /// Асинхронно отправляет билеты на указанный адрес электронной почты.
        /// </summary>
        /// <param name="email">Адрес электронной почты получателя.</param>
        /// <param name="payment">Объект платежа, связанный с билетами.</param>
        /// <param name="token">Токен отмены для управления асинхронной операцией.</param>
        /// <returns>Задача, представляющая асинхронную операцию.</returns>
        public Task SendTicketsAsync(string email, Payment payment, CancellationToken token);
    }
}
