using Microsoft.EntityFrameworkCore.Query;

namespace BusStationPlatform.Domains.Entities
{
    /// <summary>
    /// Представляет место на маршруте.
    /// </summary>
    public class Place
    {
        /// <summary>
        /// Уникальный идентификатор места.
        /// </summary>
        public int PlaceID { get; set; }

        /// <summary>
        /// Идентификатор маршрута, к которому принадлежит место.
        /// </summary>
        public int RouteID { get; set; }

        /// <summary>
        /// Номер места.
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// Номер секции, к которой принадлежит место.
        /// </summary>
        public int SectionNumber { get; set; }
    }
}
