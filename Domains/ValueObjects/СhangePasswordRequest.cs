/// <summary>
/// Запрос на смену пароля пользователя.
/// </summary>
namespace BusStationPlatform.Domains.ValueObjects
{
    public class СhangePasswordRequest
    {
        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Телефон пользователя.
        /// </summary>
        public required string Phone { get; set; }

        /// <summary>
        /// Новый пароль пользователя.
        /// </summary>
        public required string Password { get; set; }
    }
}
