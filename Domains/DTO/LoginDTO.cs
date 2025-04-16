namespace BusStationPlatform.Domains.DTO
{
    /// <summary>
    /// Представляет данные для аутентификации пользователя.
    /// </summary>
    public class LoginDTO
    {
        /// <summary>
        /// Получает или задает электронную почту пользователя.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Получает или задает пароль пользователя.
        /// </summary>
        public string? Password { get; set; }
    }
}
