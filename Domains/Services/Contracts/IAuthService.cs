using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.DTO;

namespace BusStationPlatform.Domains.Services.Contracts
{
    /// <summary>
    /// Интерфейс для сервиса аутентификации пользователей.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Регистрирует нового пользователя.
        /// </summary>
        /// <param name="user">Данные нового пользователя.</param>
        /// <returns>Зарегистрированный пользователь или null, если регистрация не удалась.</returns>
        public Task<User?> RegisterAsync(User user);

        /// <summary>
        /// Аутентифицирует пользователя на основе предоставленных данных.
        /// </summary>
        /// <param name="loginDTO">Данные для аутентификации пользователя.</param>
        /// <returns>Пользователь, если аутентификация успешна; иначе null.</returns>
        public Task<User?> LoginAsync(LoginRequestDTO loginDTO);

        /// <summary>
        /// Изменяет пароль пользователя на основе предоставленных данных.
        /// </summary>
        /// <param name="loginDTO">Данные для смены пароля пользователя.</param>
        /// <returns>Пользователь, если смена пароля успешна; иначе null.</returns>
        public Task<User?> ChangePasswordAsync(LoginRequestDTO loginDTO); 
    }
}
