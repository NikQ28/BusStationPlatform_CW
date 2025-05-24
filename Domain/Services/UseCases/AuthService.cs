using BusStationPlatform.Domain.Entities;
using BusStationPlatform.Domain.Services.Contracts;
using BusStationPlatform.Domain.Services.Contracts.Repositories;
using BusStationPlatform.Domain.ValueObjects;

namespace BusStationPlatform.Domain.Services.UseCases
{
    public class AuthService(IUserRepository userRepository) : IAuthService
    {
        public async Task<(string? error, User? result)> RegisterAsync(User newUser, CancellationToken token)
        {
            var result = await userRepository.GetUserByEmailAsync(newUser.Email, token);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
            return result == null 
                ? (null, await userRepository.CreateUserAsync(newUser, token))
                : ("Пользователь с данным адресом электронной почты уже существует", null);
        }

        public async Task<(string? error, User? result)> LoginAsync(LoginRequest loginRequest, CancellationToken token)
        {
            var user = await userRepository.GetUserByEmailAsync(loginRequest.Email, token);
            if (user == null) return ("Пользователь не найден", null);
            return !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password) 
                ? ("Введён неправильный пароль", null) 
                : (null, user);
        }

        public async Task<(string? error, User? result)> ChangePasswordAsync(LoginRequest loginRequest, string phone, CancellationToken token)
        {
            var user = await userRepository.GetUserByEmailAsync(loginRequest.Email, token);
            if (user == null) return ("Пользователь не найден", null);
            if (user.Phone != phone) return ("Непральный номер телефона", null);
            user.Password = BCrypt.Net.BCrypt.HashPassword(loginRequest.Password);
            await userRepository.UpdateUserAsync(user, token);
            return (null, user);
        }
    }
}
