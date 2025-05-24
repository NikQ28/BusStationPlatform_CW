using System.ComponentModel.DataAnnotations;

namespace BusStationPlatform.Domain.ValueObjects
{
    /// <summary>
    /// Представляет запрос на возврат билета.
    /// </summary>
    public class ReturnTicketRequest
    {
        /// <summary>
        /// Идентификатор билета.
        /// </summary>
        [Required(ErrorMessage = "Идентификатор билета обязателен.")]
        public int TicketId { get; set; }

        /// <summary>
        /// Фамилия для подтверждения.
        /// </summary>
        [Required(ErrorMessage = "Фамилия обязательна.")]
        public string Surname { get; set; }
    }
}
