using BusStationPlatform.Domain.Entities;

namespace BusStationPlatform.Domain.Services.Contracts.Repositories
{
    /// <summary>
    /// Интерфейс для работы с пользователями.
    /// </summary>
    public interface IUserRepository
    {
        public Task<User?> GetUserByIdAsync(int id, CancellationToken token);

        public Task<User?> GetUserByEmailAsync(string username, CancellationToken token);

        public Task<User?> CreateUserAsync(User newUser, CancellationToken token);

        public Task<User?> UpdateUserAsync(User updatedUser, CancellationToken token);

        public Task<int?> DeleteUserAsync(int id, CancellationToken token);

    }
}
