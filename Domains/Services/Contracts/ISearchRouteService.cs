using BusStationPlatform.Domains.ValueObjects;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services.Contracts
{
    /// <summary>
    /// Интерфейс для поиска маршрутов.
    /// </summary>
    public interface ISearchRouteService
    {
        /// <summary>
        /// Получает список маршрутов по заданным параметрам поиска.
        /// </summary>
        /// <param name="routeRequest">Параметры поиска маршрута.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Кортеж, содержащий ошибку (если есть) и список найденных маршрутов.</returns>
        public Task<(string? error, List<Route>? result)> GetRoutesAsync(SearchRouteRequest routeRequest, CancellationToken token);
    }
}
