using BusStationPlatform.Domains.Entities;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services.Contracts
{
    public interface ITicketRepository
    {
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
    }
}
