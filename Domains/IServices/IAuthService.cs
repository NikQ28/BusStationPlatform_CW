using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.DTO;

namespace BusStationPlatform.Domains.IServices
{
    public interface IAuthService
    {
        public Task<User?> RegisterAsync(User user);

        public Task<User?> LoginAsync(LoginDTO loginDTO);
    }
}
