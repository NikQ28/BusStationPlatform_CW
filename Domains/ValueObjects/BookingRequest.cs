using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.ValueObjects
{
    /// <summary>
    /// Объект передачи данных для запроса на бронирование билетов.
    /// </summary>
    public class BookingRequest
    {
        /// <summary>
        /// Идентификатор маршрута, для которого осуществляется бронирование.
        /// </summary>
        public required int RouteId { get; set; }

        /// <summary>
        /// Список пассажиров, для которых осуществляется бронирование.
        /// </summary>
        public required List<Passenger> Passengers { get; set; }

        /// <summary>
        /// Список идентификаторов мест, которые необходимо забронировать.
        /// </summary>
        public required List<int> SeatsIds { get; set; }
    }
}
