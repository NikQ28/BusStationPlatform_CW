using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.Services.Contracts
{
    public interface IUserRepository
    {

        /// <summary>
        /// Получает пользователя по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Пользователь или null, если не найден.</returns>
        public Task<User?> GetUserByIdAsync(int id);

        /// <summary>
        /// Получает пользователя по его электронной почте.
        /// </summary>
        /// <param name="username">Электронная почта пользователя.</param>
        /// <returns>Пользователь или null, если не найден.</returns>
        public Task<User?> GetUserByEmailAsync(string username);

        /// <summary>
        /// Создает нового пользователя.
        /// </summary>
        /// <param name="newUser">Новый пользователь.</param>
        public Task<User?> CreateUserAsync(User newUser);

        /// <summary>
        /// Обновляет информацию о пользователе.
        /// </summary>
        /// <param name="updatedUser">Обновленный пользователь.</param>
        /// <returns>Обновленный пользователь или null, если не найден.</returns>
        public Task<User?> UpdateUserAsync(User updatedUser);

        /// <summary>
        /// Удаляет пользователя по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        public Task<int?> DeleteUserAsync(int id);

    }
}
