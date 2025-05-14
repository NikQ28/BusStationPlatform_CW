using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.ValueObjects;

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
        /// <param name="user">Пользователь, которого необходимо зарегистрировать.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Кортеж, содержащий ошибку (если есть) и зарегистрированного пользователя.</returns>
        public Task<(string? error, User? result)> RegisterAsync(User user, CancellationToken token);

        /// <summary>
        /// Выполняет вход пользователя в систему.
        /// </summary>
        /// <param name="loginRequest">Данные для входа пользователя.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Кортеж, содержащий ошибку (если есть) и пользователя.</returns>
        public Task<(string? error, User? result)> LoginAsync(LoginRequest loginRequest, CancellationToken token);

        /// <summary>
        /// Изменяет пароль пользователя.
        /// </summary>
        /// <param name="changePasswordRequest">Данные для смены пароля.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Кортеж, содержащий ошибку (если есть) и пользователя.</returns>
        public Task<(string? error, User? result)> ChangePasswordAsync(СhangePasswordRequest changePasswordRequest, CancellationToken token);
    }
}
