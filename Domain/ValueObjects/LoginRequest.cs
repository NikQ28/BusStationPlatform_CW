using System.ComponentModel.DataAnnotations;

namespace BusStationPlatform.Domain.ValueObjects
{
    /// <summary>
    /// Представляет запрос на вход пользователя.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        [Required(ErrorMessage = "Электронная почта обязательна.")]
        public string Email { get; set; }
        
        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        [Required(ErrorMessage = "Пароль обязателен.")]
        public string Password { get; set; }
    }
}
