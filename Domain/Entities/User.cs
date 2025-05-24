using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusStationPlatform.Domain.Entities
{
    /// <summary>
    /// Представляет пользователя системы.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        [JsonIgnore]
        public int UserId { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        [Required]
        [JsonIgnore]
        public string Password { get; set; }

        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Номер телефона пользователя.
        /// </summary>
        [Required]
        public string Phone { get; set; }
    }
}
