using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;
using BusStationPlatform.Domains.Services.Contracts.Repositories;
using BusStationPlatform.Domains.ValueObjects;

namespace BusStationPlatform.Domains.Services.UseCases
{
    public class AuthService(IUserRepository userRepository) : IAuthService
    {
        public async Task<(string? error, User? result)> RegisterAsync(User newUser, CancellationToken token)
        {
            var result = await userRepository.GetUserByEmailAsync(newUser.Email, token);
            return result == null 
                ? (null, await userRepository.CreateUserAsync(newUser, token))
                : ("Пользователь с данным адресом электронной почты уже существует", null);
        }

        public async Task<(string? error, User? result)> LoginAsync(LoginRequest loginRequest, CancellationToken token)
        {
            var user = await userRepository.GetUserByEmailAsync(loginRequest.Email, token);
            if (user == null) return ("Пользователь не найден", null);
            if (user.Password != loginRequest.Password) return ("Введён неправильный пароль", null);
            return (null, user);
        }

        public async Task<(string? error, User? result)> ChangePasswordAsync(СhangePasswordRequest changePasswordRequest, CancellationToken token)
        {
            var user = await userRepository.GetUserByEmailAsync(changePasswordRequest.Email, token);
            if (user == null) return ("Пользователь не найден", null);
            if (user.Phone != changePasswordRequest.Phone) return ("Непральный номер телефона", null);
            user.Password = changePasswordRequest.Password;
            await userRepository.UpdateUserAsync(user, token);
            return (null, user);
        }
    }
}
