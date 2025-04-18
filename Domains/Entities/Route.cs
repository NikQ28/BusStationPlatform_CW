﻿namespace BusStationPlatform.Domains.Entities
{
    /// <summary>
    /// Представляет маршрут.
    /// </summary>
    public class Route
    {
        /// <summary>
        /// Уникальный идентификатор маршрута.
        /// </summary>
        public required int RouteID { get; set; }

        /// <summary>
        /// Точка отправления маршрута.
        /// </summary>
        public required string DeparturePoint { get; set; }

        /// <summary>
        /// Точка назначения маршрута.
        /// </summary>
        public required string ArrivalPoint { get; set; }

        /// <summary>
        /// Дата и время отправления маршрута.
        /// </summary>
        public required DateTime DepartureDatetime { get; set; }

        /// <summary>
        /// Цена билета на маршрут.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Число свободных мест для бронирования.
        /// </summary>
        public required int AvaliablePlaces { get; set; } 
    }
}
