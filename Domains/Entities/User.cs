using System.Text.Json.Serialization;

namespace BusStationPlatform.Domains.Entities
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
        public required string Username { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Номер телефона пользователя.
        /// </summary>
        public required string Phone { get; set; }
    }
}
