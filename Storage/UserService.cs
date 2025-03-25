using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;
using BusStationPlatform.Storage;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Domains.Services
{
    public class UserService(ApplicationContext _context) : IUserService
    {
        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Username == username);
            if (user == null)
                return null;
            return user;
        }

        public async Task<User> CreateUserAsync(UserDTO userDTO)
        {
            var user = userDTO.ToUser();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User updatedUser)
        {
            var user = await _context.Users.FindAsync(updatedUser.UserID);
            if (user == null)
                return null;
            _context.Update(updatedUser);
            await _context.SaveChangesAsync();
            return updatedUser;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
} 