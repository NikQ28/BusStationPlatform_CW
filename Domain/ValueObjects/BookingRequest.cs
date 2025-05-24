using System.ComponentModel.DataAnnotations;

using BusStationPlatform.Domain.Entities;

namespace BusStationPlatform.Domain.ValueObjects
{
    /// <summary>
    /// Представляет запрос на бронирование.
    /// </summary>
    public class BookingRequest
    {
        /// <summary>
        /// Идентификатор маршрута.
        /// </summary>
        [Required(ErrorMessage = "Идентификатор маршрута обязателен.")]
        public int RouteId { get; set; }

        /// <summary>
        /// Список пассажиров, для которых осуществляется бронирование.
        /// </summary>
        [Required(ErrorMessage = "Список посажиров обязательно")]
        public List<Passenger> Passengers { get; set; }

        /// <summary>
        /// Список идентификаторов мест, которые необходимо забронировать.
        /// </summary>
        [Required(ErrorMessage = "Список идентификаторов мест обязательно")]
        public List<int> SeatsIds { get; set; }
    }
}
