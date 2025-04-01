using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Storage;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services
{
    public class Repository(ApplicationContext _context) : IRepository
    {
        /// <summary>
        /// Получает пользователя по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Пользователь с указанным идентификатором или null, если не найден.</returns>
        public async Task<User?> GetUserByIdAsync(int id) => await _context.Users.FindAsync(id);

        /// <summary>
        /// Получает пользователя по его электронной почте.
        /// </summary>
        /// <param name="email">Электронная почта пользователя.</param>
        /// <returns>Пользователь с указанной электронной почтой или null, если не найден.</returns>
        public async Task<User?> GetUserByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        /// <summary>
        /// Создает нового пользователя.
        /// </summary>
        /// <param name="newUser">Новый пользователь для добавления.</param>
        public async Task CreateUserAsync(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновляет существующего пользователя.
        /// </summary>
        /// <param name="updatedUser">Пользователь с обновленными данными.</param>
        /// <returns>Обновленный пользователь или null, если не найден.</returns>
        public async Task<User?> UpdateUserAsync(User updatedUser)
        {
            var user = await _context.Users.FindAsync(updatedUser.UserID);
            if (user == null)
                return null;
            _context.Update(updatedUser);
            await _context.SaveChangesAsync();
            return updatedUser;
        }

        /// <summary>
        /// Удаляет пользователя по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пользователя для удаления.</param>
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получает список пассажиров, связанных с указанным пользователем.
        /// </summary>
        /// <param name="user">Пользователь, для которого нужно получить пассажиров.</param>
        /// <returns>Список пассажиров, связанных с пользователем.</returns>
        public async Task<List<Passenger>> GetUserPassengersAsync(User user)
        {
            var passengersID = await GetUserPassengersIDAsync(user);
            return await _context.Passengers.Where(passenger => passengersID.Contains(passenger.PassengerID)).ToListAsync();
        }

        /// <summary>
        /// Получает идентификаторы пассажиров, связанных с указанным пользователем.
        /// </summary>
        /// <param name="user">Пользователь, для которого нужно получить идентификаторы пассажиров.</param>
        /// <returns>Список идентификаторов пассажиров.</returns>
        public async Task<List<int>> GetUserPassengersIDAsync(User user) =>
            await _context.Passengers
                .Where(u => u.UserID == user.UserID)
                .Select(u => u.PassengerID)
                .ToListAsync();

        /// <summary>
        /// Получает пассажира по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пассажира.</param>
        /// <returns>Пассажир с указанным идентификатором или null, если не найден.</returns>
        public async Task<Passenger?> GetPassengerByIDAsync(int id) =>
            await _context.Passengers.FindAsync(id);

        /// <summary>
        /// Создает нового пассажира.
        /// </summary>
        /// <param name="newPassenger">Новый пассажир для добавления.</param>
        public async Task CreatePassengerAsync(Passenger newPassenger)
        {
            _context.Passengers.Add(newPassenger);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновляет существующего пассажира.
        /// </summary>
        /// <param name="updatedPassenger">Пассажир с обновленными данными.</param>
        /// <returns>Обновленный пассажир или null, если не найден.</returns>
        public async Task<Passenger?> UpdatePassengerAsync(Passenger updatedPassenger)
        {
            var passenger = await _context.Passengers.FindAsync(updatedPassenger.PassengerID);
            if (passenger == null)
                return null;
            _context.Update(updatedPassenger);
            await _context.SaveChangesAsync();
            return updatedPassenger;
        }

        /// <summary>
        /// Удаляет пассажира по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор пассажира для удаления.</param>
        public async Task DeletePassengerAsync(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получает билет по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор билета.</param>
        /// <returns>Билет с указанным идентификатором или null, если не найден.</returns>
        public async Task<Ticket?> GetTicketByIDAsync(int id) =>
            await _context.Tickets.FindAsync(id);

        /// <summary>
        /// Создает новый билет.
        /// </summary>
        /// <param name="ticket">Новый билет для добавления.</param>
        public async Task CreateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Удаляет билет по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор билета для удаления.</param>
        public async Task DeleteTicketAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получает список билетов, связанных с указанным пассажиром.
        /// </summary>
        /// <param name="passenger">Пассажир, для которого нужно получить билеты.</param>
        /// <returns>Список билетов, связанных с пассажиром.</returns>
        public async Task<List<Ticket>> GetPassengerTicketsAsync(Passenger passenger)
        {
            var ticketsID = await GetPassengerTicketsIDAsync(passenger);
            return await _context.Tickets.Where(ticket => ticketsID.Contains(ticket.TicketID)).ToListAsync();
        }

        /// <summary>
        /// Получает идентификаторы билетов, связанных с указанным пассажиром.
        /// </summary>
        /// <param name="passenger">Пассажир, для которого нужно получить идентификаторы билетов.</param>
        /// <returns>Список идентификаторов билетов.</returns>
        public async Task<List<int>> GetPassengerTicketsIDAsync(Passenger passenger) =>
            await _context.Tickets
                .Where(p => p.PassengerID == passenger.PassengerID)
                .Select(p => p.TicketID)
                .ToListAsync();

        /// <summary>
        /// Получает маршруты по точкам отправления и назначения на указанную дату.
        /// </summary>
        /// <param name="depaturePoint">Точка отправления.</param>
        /// <param name="arrivalPoint">Точка назначения.</param>
        /// <param name="date">Дата отправления.</param>
        /// <returns>Список маршрутов, соответствующих критериям.</returns>
        public async Task<List<Route>> GetRoutesByPointsDateAsync(string depaturePoint, string arrivalPoint, DateTime date)
        {
            var routesID = await GetRoutesIDByPointsDateAsync(depaturePoint, arrivalPoint, date);
            return await _context.Routes.Where(route => routesID.Contains(route.RouteID)).ToListAsync();
        }

        /// <summary>
        /// Получает идентификаторы маршрутов по точкам отправления и назначения на указанную дату.
        /// </summary>
        /// <param name="depaturePoint">Точка отправления.</param>
        /// <param name="arrivalPoint">Точка назначения.</param>
        /// <param name="date">Дата отправления.</param>
        /// <returns>Список идентификаторов маршрутов.</returns>
        public async Task<List<int>> GetRoutesIDByPointsDateAsync(string depaturePoint, string arrivalPoint, DateTime date) =>
            await _context.Routes
                .Where(r => r.DeparturePoint == depaturePoint && r.ArrivalPoint == arrivalPoint && r.DepartureDatetime == date)
                .Select(r => r.RouteID)
                .ToListAsync();

        /// <summary>
        /// Получает места на указанном маршруте.
        /// </summary>
        /// <param name="route">Маршрут, для которого нужно получить места.</param>
        /// <returns>Список мест, связанных с маршрутом.</returns>
        public async Task<List<Place>> GetRoutePlacesAsync(Route route)
        {
            var placesID = await GetRoutePlacesIDAsync(route);
            return await _context.Places.Where(place => placesID.Contains(place.PlaceID)).ToListAsync();
        }

        /// <summary>
        /// Получает идентификаторы мест на указанном маршруте.
        /// </summary>
        /// <param name="route">Маршрут, для которого нужно получить идентификаторы мест.</param>
        /// <returns>Список идентификаторов мест.</returns>
        public async Task<List<int>> GetRoutePlacesIDAsync(Route route) =>
            await _context.Places
                .Where(p => p.RouteID == route.RouteID)
                .Select(p => p.PlaceID)
                .ToListAsync();

        /// <summary>
        /// Получает билеты, связанные с указанным маршрутом.
        /// </summary>
        /// <param name="route">Маршрут, для которого нужно получить билеты.</param>
        /// <returns>Список билетов, связанных с маршрутом.</returns>
        public async Task<List<Ticket>> GetRouteTicketsAsync(Route route)
        {
            var ticketsID = await GetRouteTicketsIDAsync(route);
            return await _context.Tickets.Where(ticket => ticketsID.Contains(ticket.TicketID)).ToListAsync();
        }

        /// <summary>
        /// Получает идентификаторы билетов, связанных с указанным маршрутом.
        /// </summary>
        /// <param name="route">Маршрут, для которого нужно получить идентификаторы билетов.</param>
        /// <returns>Список идентификаторов билетов.</returns>
        public async Task<List<int>> GetRouteTicketsIDAsync(Route route) =>
            await _context.Tickets
                .Where(t => t.RouteID == route.RouteID)
                .Select(t => t.TicketID)
                .ToListAsync();

        /// <summary>
        /// Получает занятое мето по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор занятого места.</param>
        /// <returns>Занятое место с указанным идентификатором или null, если не найдена.</returns>
        public async Task<OccupiedPlace?> GetOccupiedPlaceByIDAsync(int id) =>
            await _context.OccupiedPlaces.FindAsync(id);
    }
} 