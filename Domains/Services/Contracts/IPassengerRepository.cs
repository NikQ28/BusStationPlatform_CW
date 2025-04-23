using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.Services.Contracts
{
    public interface IPassengerRepository
    {
        /// <summary>
        /// Получает пассажира по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пассажира.</param>
        /// <returns>Пассажир или null, если не найден.</returns>
        public Task<Passenger?> GetPassengerByIDAsync(int id);

        /// <summary>
        /// Получает пассажира по его паспорту.
        /// </summary>
        /// <param name="passport">Паспорт пассажира.</param>
        /// <returns>Пассажир или null, если не найден.</returns>
        public Task<Passenger?> GetPassengerByPassportAsync(string passport);

        /// <summary>
        /// Создает нового пассажира.
        /// </summary>
        /// <param name="newPassenger">Новый пассажир.</param>
        public Task<Passenger?> CreatePassengerAsync(Passenger newPassenger);

        /// <summary>
        /// Обновляет информацию о пассажире.
        /// </summary>
        /// <param name="updatedPassenger">Обновленный пассажир.</param>
        /// <returns>Обновленный пассажир или null, если не найден.</returns>
        public Task<Passenger?> UpdatePassengerAsync(Passenger updatedPassenger);

        /// <summary>
        /// Удаляет пассажира по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пассажира.</param>
        public Task<int?> DeletePassengerAsync(int id);

        /// <summary>
        /// Получает список пассажиров по пользователю.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Список пассажиров или null, если не найдено.</returns>
        public Task<List<Passenger>?> GetPassengersByUserAsync(User user);
    }
}
