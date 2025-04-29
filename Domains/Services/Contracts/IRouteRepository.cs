using BusStationPlatform.Domains.DTO;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services.Contracts
{
    public interface IRouteRepository
    {
        /// <summary>
        /// Получает маршрут по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Список билетов или null, если не найдено.</returns>
        public Task<Route?> GetRouteByIDAsync(int id);

        /// <summary>
        /// Получает список маршрутов по пунктам отправления, назначения и дате.
        /// </summary>
        /// <param name="departurePoint">Пункт отправления.</param>
        /// <param name="arrivalPoint">Пункт назначения.</param>
        /// <param name="date">Дата.</param>
        /// <returns>Список маршрутов или null, если не найдено.</returns>
        public Task<List<Route>?> GetRoutesByPointsDateAsync(RouteRequestDTO routeDTO);
    }
}
