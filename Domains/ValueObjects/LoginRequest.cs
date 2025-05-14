namespace BusStationPlatform.Domains.ValueObjects
{
    /// <summary>
    /// Представляет данные для аутентификации пользователя.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Получает или задает электронную почту пользователя.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Получает или задает пароль пользователя.
        /// </summary>
        public required string Password { get; set; }
    }
}
