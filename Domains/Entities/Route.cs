namespace BusStationPlatform.Domains.Entities
{
    /// <summary>
    /// Представляет маршрут.
    /// </summary>
    public class Route
    {
        /// <summary>
        /// Уникальный идентификатор маршрута.
        /// </summary>
        public int RouteID { get; set; }

        /// <summary>
        /// Точка отправления маршрута.
        /// </summary>
        public string? DeparturePoint { get; set; }

        /// <summary>
        /// Точка назначения маршрута.
        /// </summary>
        public string? ArrivalPoint { get; set; }

        /// <summary>
        /// Дата и время отправления маршрута.
        /// </summary>
        public DateTime? DepartureDatetime { get; set; }

        /// <summary>
        /// Цена билета на маршрут.
        /// </summary>
        public decimal Price { get; set; }
    }
}
