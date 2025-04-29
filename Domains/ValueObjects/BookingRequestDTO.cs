using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.DTO
{
    /// <summary>
    /// Объект передачи данных для запроса на бронирование билетов.
    /// </summary>
    public class BookingRequestDTO
    {
        /// <summary>
        /// Идентификатор маршрута, для которого осуществляется бронирование.
        /// </summary>
        public int RouteID { get; set; }

        /// <summary>
        /// Список пассажиров, для которых осуществляется бронирование.
        /// </summary>
        public List<Passenger>? Passengers { get; set; }

        /// <summary>
        /// Список идентификаторов мест, которые необходимо забронировать.
        /// </summary>
        public List<int>? PlacesID { get; set; }
    }
}
