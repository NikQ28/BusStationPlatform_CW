using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.DTO
{
    /// <summary>
    /// Представляет данные пользователя для передачи.
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Получает или задает электронную почту пользователя.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Получает или задает пароль пользователя.
        /// </summary>
        public string Password { get; set; }
    }
}
