using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.Services.Contracts.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByIdAsync(int id, CancellationToken token);

        public Task<User?> GetUserByEmailAsync(string username, CancellationToken token);

        public Task<User?> CreateUserAsync(User newUser, CancellationToken token);

        public Task<User?> UpdateUserAsync(User updatedUser, CancellationToken token);

        public Task<int?> DeleteUserAsync(int id, CancellationToken token);

    }
}
