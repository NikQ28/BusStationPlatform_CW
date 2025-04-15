using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Entities;
using Microsoft.AspNetCore.SignalR;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains
{
    public interface IRepository
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

        /// <summary>
        /// Получает билет по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор билета.</param>
        /// <returns>Билет или null, если не найден.</returns>
        public Task<Ticket?> GetTicketByIDAsync(int id);

        /// <summary>
        /// Создает новый билет.
        /// </summary>
        /// <param name="newTicket">Новый билет.</param>
        public Task<Ticket?> CreateTicketAsync(Ticket newTicket);

        /// <summary>
        /// Удаляет билет по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор билета.</param>
        public Task<int?> DeleteTicketAsync(int id);

        /// <summary>
        /// Получает список билетов по пассажиру.
        /// </summary>
        /// <param name="passenger">Пассажир.</param>
        /// <returns>Список билетов или null, если не найдено.</returns>
        public Task<List<Ticket>?> GetTicketsByPassengerAsync(Passenger passenger);

        /// <summary>
        /// Получает список билетов по маршруту.
        /// </summary>
        /// <param name="route">Маршрут.</param>
        /// <returns>Список билетов или null, если не найдено.</returns>
        public Task<List<Ticket>?> GetTicketsByRouteAsync(Route route);

        /// <summary>
        /// Получает список билетов по счету.
        /// </summary>
        /// <param name="invoice">Счет.</param>
        /// <returns>Список билетов или null, если не найдено.</returns>
        public Task<List<Ticket>?> GetTicketsByInvoiceAsync(Invoice invoice);

        /// <summary>
        /// Получает маршрут по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Список билетов или null, если не найдено.</returns>
        public Task<Route?> GetRouteByIDAsync(int id);

        /// <summary>
        /// Получает список маршрутов по пунктам отправления, назначения и дате.
        /// </summary>
        /// <param name="departurePoint">Пункт отправления.</param>
        /// <param name="arrivalPoint">Пункт назначения.</param>
        /// <param name="date">Дата.</param>
        /// <returns>Список маршрутов или null, если не найдено.</returns>
        public Task<List<Route>?> GetRoutesByPointsDateAsync(RouteDTO routeDTO);

        /// <summary>
        /// Получает список мест по маршруту.
        /// </summary>
        /// <param name="route">Маршрут.</param>
        /// <returns>Список мест или null, если не найдено.</returns>
        public Task<List<Place>?> GetPlacesByRouteAsync(Route route);

        /// <summary>
        /// Получает счет по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор счета.</param>
        /// <returns>Счет или null, если не найден.</returns>
        public Task<Invoice?> GetInvoiceByIDAsync(int id);

        /// <summary>
        /// Создает новый счет.
        /// </summary>
        /// <param name="newInvoice">Новый счет.</param>
        public Task<Invoice?> CreateInvoiceAsync(Invoice newInvoice);

        /// <summary>
        /// Получает список платежей по пользователю.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Список платежей или null, если не найдено.</returns>
        public Task<List<Payment>?> GetPaymentsByUserAsync(User user);

        /// <summary>
        /// Получает платеж по счету.
        /// </summary>
        /// <param name="invoice">Счет.</param>
        /// <returns>Платеж или null, если не найден.</returns>
        public Task<Payment?> GetPaymentByInvoiceAsync(Invoice invoice);

        /// <summary>
        /// Создает новый платеж.
        /// </summary>
        /// <param name="newPayment">Новый платеж.</param>
        public Task<Payment?> CreatePaymentAsync(Payment newPayment);

        /// <summary>
        /// Получает занятое место по билету.
        /// </summary>
        /// <param name="ticket">Билет.</param>
        /// <returns>Занятое место или null, если не найдено.</returns>
        public Task<OccupiedPlace?> GetOccupiedPlaceByTicketAsync(Ticket ticket);

        /// <summary>
        /// Получает занятое место по месту.
        /// </summary>
        /// <param name="place">Место.</param>
        /// <returns>Занятое место или null, если не найдено.</returns>
        public Task<OccupiedPlace?> GetOccupiedPlaceByPlaceAsync(Place place);
    }
}
