using BusStationPlatform.Domain.ValueObjects;

namespace BusStationPlatform.Domain.Services.Contracts
{
    /// <summary>
    /// Интерфейс для сервиса возврата билетов.
    /// </summary>
    public interface IReturnTicketService
    {
        /// <summary>
        /// Осуществляет возврат билета по предоставленным данным.
        /// </summary>
        /// <param name="returnTicketRequest">Данные для возврата билета.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Кортеж, содержащий ошибку (если есть) и идентификатор возвращённого билета.</returns>
        public Task<(string? error, int? result)> ReturnTicketAsync(ReturnTicketRequest returnTicketRequest, CancellationToken token);
    }
}
