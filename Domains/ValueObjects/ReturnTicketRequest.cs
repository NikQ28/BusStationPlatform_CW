namespace BusStationPlatform.Domains.ValueObjects
{
/// <summary>
/// Запрос на возврат билета.
/// </summary>
    public class ReturnTicketRequest
    {
    /// <summary>
    /// Идентификатор билета, который требуется вернуть.
    /// </summary>
        public required int TicketId { get; set; }

        /// <summary>
        /// Фамилия владельца билета.
        /// </summary>
        public required string Surname { get; set; }
    }
}
