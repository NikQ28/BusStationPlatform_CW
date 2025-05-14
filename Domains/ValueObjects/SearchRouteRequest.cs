namespace BusStationPlatform.Domains.ValueObjects
{
    /// <summary>
    /// Представляет данные маршрута для передачи.
    /// </summary>
    public class SearchRouteRequest
    {
        /// <summary>
        /// Получает или задает пункт отправления маршрута.
        /// </summary>
        public required string DeparturePoint { get; set; }

        /// <summary>
        /// Получает или задает пункт назначения маршрута.
        /// </summary>
        public required string ArrivalPoint { get; set; }

        /// <summary>
        /// Получает или задает дату и время отправления маршрута.
        /// </summary>
        public required DateOnly DepartureDatetime { get; set; }
    }
}
