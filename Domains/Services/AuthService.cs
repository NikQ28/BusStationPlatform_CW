using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.IServices;

namespace BusStationPlatform.Domains.Services
{
    public class AuthService(IRepository _repository) : IAuthService
    {
        public async Task<User?> RegisterAsync(User newUser)
        {
            if (await IsUserExistsAsync(newUser))
                return null;
            return await _repository.CreateUserAsync(newUser);
        }

        public async Task<bool> IsUserExistsAsync(User user)
        {
            if (await _repository.GetUserByEmailAsync(user.Email) == null)
                return false;
            return true;
        }

        public async Task<User?> LoginAsync(LoginDTO loginDTO)
        {
            if (await _repository.GetUserByEmailAsync(loginDTO.Email) == null)
                return null;

            var user = await _repository.GetUserByEmailAsync(loginDTO.Email);
            if (user.Password != loginDTO.Password)
                return null;

            return user;
        }
    }
}
