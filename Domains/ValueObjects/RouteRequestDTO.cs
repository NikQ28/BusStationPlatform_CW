namespace BusStationPlatform.Domains.DTO
{
    /// <summary>
    /// Представляет данные маршрута для передачи.
    /// </summary>
    public class RouteRequestDTO
    {
        /// <summary>
        /// Получает или задает пункт отправления маршрута.
        /// </summary>
        public string? DeparturePoint { get; set; }

        /// <summary>
        /// Получает или задает пункт назначения маршрута.
        /// </summary>
        public string? ArrivalPoint { get; set; }

        /// <summary>
        /// Получает или задает дату и время отправления маршрута.
        /// </summary>
        public DateOnly DepartureDateTime { get; set; }
    }
}
