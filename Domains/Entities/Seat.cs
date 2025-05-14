using Microsoft.EntityFrameworkCore.Query;

namespace BusStationPlatform.Domains.Entities
{
    /// <summary>
    /// Представляет место на маршруте.
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// Уникальный идентификатор места.
        /// </summary>
        public int SeatId { get; set; }

        /// <summary>
        /// Идентификатор маршрута, к которому принадлежит место.
        /// </summary>
        public int RouteId { get; set; }

        /// <summary>
        /// Номер места.
        /// </summary>
        public int SeatNumber { get; set; }

        /// <summary>
        /// Номер секции, к которой принадлежит место.
        /// </summary>
        public int SectionNumber { get; set; }
    }
}
