using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.DTO;
using Microsoft.AspNetCore.Mvc;

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
        /// <param name="routeID">Идентификатор маршрута, для которого необходимо получить свободные места.</param>
        /// <returns>Асинхронная задача, представляющая результат операции. Результат задачи содержит список свободных мест, если они найдены; в противном случае - null.</returns>
        public Task<List<Place>?> GetFreePlacesAsync(int routeID);

        /// <summary>
        /// Бронирует билеты на основе предоставленного запроса.
        /// </summary>
        /// <param name="requestDTO">Объект, содержащий данные для бронирования билетов.</param>
        /// <returns>Асинхронная задача, представляющая результат операции. Результат задачи содержит счет-фактуру, если бронирование прошло успешно; в противном случае - null.</returns>
        public Task<Invoice?> BookTicketsAsync(BookingRequestDTO requestDTO);
    }
}
