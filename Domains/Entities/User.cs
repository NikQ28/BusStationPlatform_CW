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
        public int UserID { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона пользователя.
        /// </summary>
        public string? Phone { get; set; }
    }
}
