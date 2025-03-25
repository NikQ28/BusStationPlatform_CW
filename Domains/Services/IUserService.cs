using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;

namespace BusStationPlatform.Domains.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(UserDTO userDTO);
        Task<User> UpdateUserAsync(User updatedUser);
        Task DeleteUserAsync(int id);
    }
} 