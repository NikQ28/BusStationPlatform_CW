using System.ComponentModel.DataAnnotations;

namespace BusStationPlatform.Domain.ValueObjects
{
    /// <summary>
    /// Представляет запрос на поиск маршрута.
    /// </summary>
    public class SearchRouteRequest
    {
        /// <summary>
        /// Место отправления.
        /// </summary>
        [Required(ErrorMessage = "Начальная точка обязательна.")]
        public string DeparturePoint { get; set; }

        /// <summary>
        /// Место прибытия.
        /// </summary>
        [Required(ErrorMessage = "Конечная точка обязательна.")]
        public string ArrivalPoint { get; set; }

        /// <summary>
        /// Дата поездки.
        /// </summary>
        [Required(ErrorMessage = "Дата поездки обязательна.")]
        public DateOnly DepartureDatetime { get; set; }
    }
}
