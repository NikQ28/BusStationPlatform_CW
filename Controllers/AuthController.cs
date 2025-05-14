using Microsoft.AspNetCore.Mvc;

using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;
using BusStationPlatform.Domains.ValueObjects;

namespace BusStationPlatform.Controllers
{
    /// <summary>
    /// Контроллер для аутентификации пользователей.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        /// <summary>
        /// Регистрирует нового пользователя.
        /// </summary>
        /// <param name="newUser">Данные нового пользователя.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Результат регистрации пользователя.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromQuery] User newUser, CancellationToken token)
        {
            var (error, user) = await authService.RegisterAsync(newUser, token);
            if (!string.IsNullOrWhiteSpace(error)) return NotFound(error);
            return Ok(user);
        }

        /// <summary>
        /// Выполняет вход пользователя в систему.
        /// </summary>
        /// <param name="loginRequest">Данные для входа пользователя.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Результат входа пользователя.</returns>
        [HttpGet("authentication")]
        public async Task<IActionResult> LoginAsync([FromQuery] LoginRequest loginRequest, CancellationToken token)
        {
            var (error, user) = await authService.LoginAsync(loginRequest, token);
            if (!string.IsNullOrWhiteSpace(error))
                return (error == "Пользователь не найден") ? NotFound(error) : BadRequest(error);
            return Ok(user);
        }

        /// <summary>
        /// Изменяет пароль пользователя.
        /// </summary>
        /// <param name="changePasswordRequest">Данные для смены пароля.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Результат изменения пароля.</returns>
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePasswordAsync([FromQuery] СhangePasswordRequest changePasswordRequest, CancellationToken token)
        {
            var (error, user) = await authService.ChangePasswordAsync(changePasswordRequest, token);
            if (!string.IsNullOrWhiteSpace(error))
                return (error == "Пользователь не найден") ? NotFound(error) : BadRequest(error);
            return Ok(user);
        }
    }
}
