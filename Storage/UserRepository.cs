using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Storage
{
    public class UserRepository(BusStationPlatformContext _context) : IUserRepository
    {
        public async Task<User?> GetUserByIdAsync(int id) =>
            await _context.User.FindAsync(id);

        public async Task<User?> GetUserByEmailAsync(string email) =>
            await _context.User.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User?> CreateUserAsync(User newUser)
        {
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User?> UpdateUserAsync(User updatedUser)
        {
            var user = await _context.User.FindAsync(updatedUser.UserID);
            if (user == null)
                return null;
            _context.Update(updatedUser);
            await _context.SaveChangesAsync();
            return updatedUser;
        }

        public async Task<int?> DeleteUserAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
                return id;
            }
            return null;
        }
    }
}
