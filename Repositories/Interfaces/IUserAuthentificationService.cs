using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.DTO;

namespace BusStationPlatform.Repositories.Interfaces
{
    /// <summary>
    /// Интерфейс для сервиса аутентификации пользователей.
    /// </summary>
    public interface IUserAuthentificationService
    {
        /// <summary>
        /// Аутентифицирует пользователя на основе предоставленных данных.
        /// </summary>
        /// <param name="userDTO">Данные пользователя для аутентификации.</param>
        /// <returns>Пользователь, если аутентификация успешна; иначе null.</returns>
        public Task<User?> AuthentificationAsync(UserDTO userDTO);

        /// <summary>
        /// Изменяет пароль пользователя.
        /// </summary>
        /// <param name="userDTO">Данные пользователя с новым паролем.</param>
        /// <returns>Обновленный пользователь.</returns>
        public Task<User> ChangePasswordAsync(UserDTO userDTO);

        /// <summary>
        /// Регистрирует нового пользователя.
        /// </summary>
        /// <param name="newUser">Новый пользователь для регистрации.</param>
        /// <returns>Зарегистрированный пользователь или null, если регистрация не удалась.</returns>
        public Task<User?> RegisterAsync(User newUser);
    }
}
