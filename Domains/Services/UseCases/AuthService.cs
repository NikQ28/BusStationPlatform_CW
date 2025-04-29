using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace BusStationPlatform.Domains.Services
{
    public class AuthService(IUserRepository _userRepository) : IAuthService
    {
        public async Task<User?> RegisterAsync(User newUser) =>
            (await IsUserExistsAsync(newUser)) ? null : await _userRepository.CreateUserAsync(newUser);

        public async Task<User?> LoginAsync(LoginRequestDTO loginDTO)
        {
            if (await _userRepository.GetUserByEmailAsync(loginDTO.Email) == null)
                return null;
            var user = await _userRepository.GetUserByEmailAsync(loginDTO.Email);
            if (user.Password != loginDTO.Password)
                return null;
            return user;
        }

        public async Task<User?> ChangePasswordAsync(LoginRequestDTO loginDTO)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDTO.Email);
            user.Password = loginDTO.Password;
            await _userRepository.UpdateUserAsync(user);
            return user;
        }

        private async Task<bool> IsUserExistsAsync(User user) =>
            await _userRepository.GetUserByEmailAsync(user.Email) == null ? false : true;
    }
}
