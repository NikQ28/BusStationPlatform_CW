using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Entities;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services.Contracts
{
    /// <summary>
    /// Интерфейс для поиска маршрутов.
    /// </summary>
    public interface ISearchRouteService
    {
        /// <summary>
        /// Получает список маршрутов на основе предоставленных данных.
        /// </summary>
        /// <param name="routeDTO">Объект, содержащий данные для поиска маршрутов.</param>
        /// <returns>Асинхронная задача, представляющая результат операции. Результат задачи содержит список маршрутов, если они найдены; в противном случае - null.</returns>
        public Task<List<Route>?> GetRoutesAsync(RouteDTO routeDTO);
    }
}
