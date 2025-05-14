namespace BusStationPlatform.Domains.Entities
{
    /// <summary>
    /// Представляет билет на маршрут.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Уникальный идентификатор билета.
        /// </summary>
        public int TicketId { get; set; }

        /// <summary>
        /// Идентификатор пассажира, которому принадлежит билет.
        /// </summary>
        public int PassengerId { get; set; }

        /// <summary>
        /// Идентификатор маршрута, на который выдан билет.
        /// </summary>
        public int RouteId { get; set; }

        /// <summary>
        /// Идентификатор счета, связанного с билетом.
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Дата и время отправления по билету.
        /// </summary>
        public DateTime DatetimeDeparture { get; set; }
    }
}
