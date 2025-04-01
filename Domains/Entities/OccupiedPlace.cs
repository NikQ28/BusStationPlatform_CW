namespace BusStationPlatform.Domains.Entities
{
    /// <summary>
    /// Представляет занятое место на маршруте.
    /// </summary>
    public class OccupiedPlace
    {
        /// <summary>
        /// Уникальный идентификатор занятого места.
        /// </summary>
        public int OccupiedPlaceID { get; set; }

        /// <summary>
        /// Идентификатор места.
        /// </summary>
        public int PlaceID { get; set; }

        /// <summary>
        /// Идентификатор билета, связанного с занятым местом.
        /// </summary>
        public int TicketID { get; set; }
    }
}
