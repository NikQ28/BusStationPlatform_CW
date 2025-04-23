using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;

namespace BusStationPlatform.Domains.Services
{
    public class AuthService(IUserRepository _userRepository) : IAuthService
    {
        public async Task<User?> RegisterAsync(User newUser) =>
            (await IsUserExistsAsync(newUser)) ? null : await _userRepository.CreateUserAsync(newUser);

        public async Task<bool> IsUserExistsAsync(User user) =>
            await _userRepository.GetUserByEmailAsync(user.Email) == null ? false : true;

        public async Task<User?> LoginAsync(LoginDTO loginDTO)
        {
            if (await _userRepository.GetUserByEmailAsync(loginDTO.Email) == null)
                return null;
            var user = await _userRepository.GetUserByEmailAsync(loginDTO.Email);
            if (user.Password != loginDTO.Password)
                return null;
            return user;
        }
    }
}
