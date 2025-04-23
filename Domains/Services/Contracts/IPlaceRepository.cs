using BusStationPlatform.Domains.Entities;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services.Contracts
{
    public interface IPlaceRepository
    {
        /// <summary>
        /// Получает список мест по маршруту.
        /// </summary>
        /// <param name="route">Маршрут.</param>
        /// <returns>Список мест или null, если не найдено.</returns>
        public Task<List<Place>?> GetPlacesByRouteAsync(Route route);

        /// <summary>
        /// Получает список мест по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Список мест или null, если не найдено.</returns>
        public Task<Place?> GetPlaceByIDAsync(int id);

        /// <summary>
        /// Создать новое занятое место.
        /// </summary>
        /// <param name="newOccupiedPlace">Новое занятое место.</param>
        /// <returns>Занятое место или null, если не найдено.</returns>
        public Task<OccupiedPlace?> CreateOccupiedPlaceAsync(OccupiedPlace newOccupiedPlace);

        /// <summary>
        /// Получает занятое место по билету.
        /// </summary>
        /// <param name="ticket">Билет.</param>
        /// <returns>Занятое место или null, если не найдено.</returns>
        public Task<OccupiedPlace?> GetOccupiedPlaceByTicketAsync(Ticket ticket);

        /// <summary>
        /// Получает занятое место по месту.
        /// </summary>
        /// <param name="place">Место.</param>
        /// <returns>Занятое место или null, если не найдено.</returns>
        public Task<OccupiedPlace?> GetOccupiedPlaceByPlaceAsync(Place place);
    }
}
