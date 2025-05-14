namespace BusStationPlatform.Domains.Entities
{
    /// <summary>
    /// Представляет занятое место на маршруте.
    /// </summary>
    public class OccupiedSeat
    {
        /// <summary>
        /// Уникальный идентификатор занятого места.
        /// </summary>
        public int OccupiedSeatId { get; set; }

        /// <summary>
        /// Идентификатор места.
        /// </summary>
        public int SeatId { get; set; }

        /// <summary>
        /// Идентификатор билета, связанного с занятым местом.
        /// </summary>
        public int TicketId { get; set; }
    }
}
