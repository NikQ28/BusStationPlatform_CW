using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using BusStationPlatform.Domain.Entities;
using BusStationPlatform.Domain.Services.Contracts;
using BusStationPlatform.Domain.ValueObjects;

namespace BusStationPlatform.Controllers
{
    /// <summary>
    /// Контроллер для аутентификации пользователей.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService, IEmailService emailService) : ControllerBase
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
            string? tempPassword = newUser.Password;
            var (error, user) = await authService.RegisterAsync(newUser, token);
            if (!string.IsNullOrWhiteSpace(error)) return NotFound(error);
            else
            {
                var claims = new List<Claim> { new (ClaimTypes.Email, user.Email) };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                await emailService.SendEmailAboutRegistrationAsync(newUser.Email, tempPassword, token);
                return Ok(user);
            }
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
            else
            {
                var claims = new List<Claim> { new (ClaimTypes.Email, user.Email) };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Ok(user);
            }
        }

        /// <summary>
        /// Изменяет пароль пользователя.
        /// </summary>
        /// <param name="loginRequest">Данные для смены пароля.</param>
        /// <param name="phone">Номер телефона для подтверждения.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Результат изменения пароля.</returns>
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePasswordAsync([FromQuery] LoginRequest loginRequest, string phone, CancellationToken token)
        {
            var (error, user) = await authService.ChangePasswordAsync(loginRequest, phone, token);
            if (!string.IsNullOrWhiteSpace(error))
                return (error == "Пользователь не найден") ? NotFound(error) : BadRequest(error);
            else
            {
                await emailService.SendEmailAboutPasswordChangeAsync(loginRequest.Email, loginRequest.Password, token);
                var claims = new List<Claim> { new (ClaimTypes.Email, user.Email) };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Ok(user);
            }
        }
    }
}
