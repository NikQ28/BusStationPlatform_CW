using BusStationPlatform.Domains.Entities;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services
{
    public interface IRepository
    {
        public Task<User?> GetUserByIdAsync(int id);
        public Task<User?> GetUserByEmailAsync(string username);
        public Task CreateUserAsync(User newUser);
        public Task<User?> UpdateUserAsync(User updatedUser);
        public Task DeleteUserAsync(int id);

        public Task<Passenger?> GetPassengerByIDAsync(int id);
        public Task CreatePassengerAsync(Passenger newPassenger);
        public Task<Passenger?> UpdatePassengerAsync(Passenger updatedPassenger);
        public Task DeletePassengerAsync(int id);

        public Task<Ticket?> GetTicketByIDAsync(int id);
        public Task CreateTicketAsync(Ticket ticket);
        public Task DeleteTicketAsync(int id);

        public Task<OccupiedPlace?> GetOccupiedPlaceByIDAsync(int id);

        public Task<List<Ticket>> GetPassengerTicketsAsync(Passenger passenger);
        public Task<List<Passenger>> GetUserPassengersAsync(User user);
        public Task<List<Route>> GetRoutesByPointsDateAsync(string departurePoint, string arrivalPoint, DateTime date);
        public Task<List<Place>> GetRoutePlacesAsync(Route route);
        public Task<List<Ticket>> GetRouteTicketsAsync(Route route);

    }
}
