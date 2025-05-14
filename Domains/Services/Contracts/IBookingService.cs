using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.ValueObjects;

namespace BusStationPlatform.Domains.Services.Contracts
{
    /// <summary>
    /// Интерфейс для управления процессом бронирования билетов.
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Получает список свободных мест для указанного маршрута.
        /// </summary>
        /// <param name="id">Идентификатор маршрута, для которого необходимо получить свободные места.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Асинхронная задача, представляющая результат операции. Результат задачи содержит список свободных мест, если они найдены; в противном случае - null.</returns>
        public Task<(string? error, List<Seat>? result)> GetFreeSeatsAsync(int id, CancellationToken token);

        /// <summary>
        /// Бронирует билеты на основе предоставленного запроса.
        /// </summary>
        /// <param name="bookingRequest">Объект, содержащий данные для бронирования билетов.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Асинхронная задача, представляющая результат операции. Результат задачи содержит счет-фактуру, если бронирование прошло успешно; в противном случае - null.</returns>
        public Task<(string? error, Invoice? result)> BookingTicketsAsync(BookingRequest bookingRequest, CancellationToken token);
    }
}
