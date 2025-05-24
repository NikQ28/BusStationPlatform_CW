using Microsoft.EntityFrameworkCore;

using BusStationPlatform.Domain.Entities;
using BusStationPlatform.Domain.Services.Contracts.Repositories;

namespace BusStationPlatform.Storage
{
    public class UserRepository(BusStationPlatformContext context) : IUserRepository
    {
        public async Task<User?> GetUserByIdAsync(int id, CancellationToken token) =>
            await context.User.FindAsync([id], token);

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken token) =>
            await context.User.FirstOrDefaultAsync(u => u.Email == email, token);

        public async Task<User?> CreateUserAsync(User newUser, CancellationToken token)
        {
            context.User.Add(newUser);
            await context.SaveChangesAsync(token);
            return newUser;
        }

        public async Task<User?> UpdateUserAsync(User updatedUser, CancellationToken token)
        {
            var user = await context.User.FindAsync([updatedUser.UserId], token);
            if (user == null)
                return null;
            context.Update(updatedUser);
            await context.SaveChangesAsync(token);
            return updatedUser;
        }

        public async Task<int?> DeleteUserAsync(int id, CancellationToken token)
        {
            var user = await context.User.FindAsync([id], token);
            if (user != null)
            {
                context.User.Remove(user);
                await context.SaveChangesAsync(token);
                return id;
            }
            return null;
        }
    }
}
