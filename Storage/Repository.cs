using BusStationPlatform.Domains;
using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Storage
{
    public class Repository(BusStationPlatformContext _context) : IRepository
    {
        public async Task<User?> GetUserByIdAsync(int id) => 
            await _context.Users.FindAsync(id);

        public async Task<User?> GetUserByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User?> CreateUserAsync(User newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User?> UpdateUserAsync(User updatedUser)
        {
            var user = await _context.Users.FindAsync(updatedUser.UserID);
            if (user == null)
                return null;
            _context.Update(updatedUser);
            await _context.SaveChangesAsync();
            return updatedUser;
        }

        public async Task<int?> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return id;
            }
            return null;
        }

        public async Task<Passenger?> GetPassengerByIDAsync(int id) =>
            await _context.Passengers.FindAsync(id);

        public async Task<Passenger?> GetPassengerByPassportAsync(string passport) =>
            await _context.Passengers.FirstOrDefaultAsync(passenger => passenger.Passport == passport);

        public async Task<Passenger?> CreatePassengerAsync(Passenger newPassenger)
        {
            _context.Passengers.Add(newPassenger);
            await _context.SaveChangesAsync();
            return newPassenger;
        }

        public async Task<Passenger?> UpdatePassengerAsync(Passenger updatedPassenger)
        {
            var passenger = await _context.Passengers.FindAsync(updatedPassenger.PassengerID);
            if (passenger == null)
                return null;
            _context.Update(updatedPassenger);
            await _context.SaveChangesAsync();
            return updatedPassenger;
        }

        public async Task<int?> DeletePassengerAsync(int id)
        {
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                await _context.SaveChangesAsync();
                return id;
            }
            return null;
        }

        public async Task<List<Passenger>?> GetPassengersByUserAsync(User user)
        {
            var passengersID = await GetPassengersIDByUserAsync(user);
            return await _context.Passengers.Where(passenger => passengersID.Contains(passenger.PassengerID)).ToListAsync();
        }

        public async Task<List<int>?> GetPassengersIDByUserAsync(User user) =>
            await _context.Passengers
                .Where(u => u.UserID == user.UserID)
                .Select(u => u.PassengerID)
                .ToListAsync();

        public async Task<Ticket?> GetTicketByIDAsync(int id) =>
            await _context.Tickets.FindAsync(id);

        public async Task<Ticket?> CreateTicketAsync(Ticket newTicket)
        {
            _context.Tickets.Add(newTicket);
            await _context.SaveChangesAsync();
            return newTicket;
        }

        public async Task<int?> DeleteTicketAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
                return id;
            }
            return null;
        }

        public async Task<List<Ticket>?> GetTicketsByPassengerAsync(Passenger passenger)
        {
            var ticketsID = await GetTicketsIDByPassengerAsync(passenger);
            return await _context.Tickets.Where(ticket => ticketsID.Contains(ticket.TicketID)).ToListAsync();
        }

        public async Task<List<int>?> GetTicketsIDByPassengerAsync(Passenger passenger) =>
            await _context.Tickets
                .Where(p => p.PassengerID == passenger.PassengerID)
                .Select(p => p.TicketID)
                .ToListAsync();

        public async Task<List<Ticket>?> GetTicketsByRouteAsync(Route route)
        {
            var ticketsID = await GetTicketsIDByRouteAsync(route);
            return await _context.Tickets.Where(ticket => ticketsID.Contains(ticket.TicketID)).ToListAsync();
        }

        public async Task<List<int>?> GetTicketsIDByRouteAsync(Route route) =>
    await _context.Tickets
        .Where(t => t.RouteID == route.RouteID)
        .Select(t => t.TicketID)
        .ToListAsync();

        public async Task<List<Ticket>?> GetTicketsByInvoiceAsync(Invoice invoice)
        {
            var ticketsID = await GetTicketsIDByInvoiceAsync(invoice);
            return await _context.Tickets.Where(ticket => ticketsID.Contains(ticket.TicketID)).ToListAsync();
        }

        public async Task<List<int>?> GetTicketsIDByInvoiceAsync(Invoice invoice) =>
            await _context.Tickets
                .Where(ticket => ticket.InvoiceID == invoice.InvoiceID)
                .Select(ticket => ticket.TicketID)
                .ToListAsync();

        public async Task<Route?> GetRouteByIDAsync(int id) =>
            await _context.Routes.FindAsync(id);

        public async Task<List<Route>?> GetRoutesByPointsDateAsync(RouteDTO routeDTO)
        {
            var routesID = await GetRoutesIDByPointsDateAsync(routeDTO);
            return await _context.Routes.Where(route => routesID.Contains(route.RouteID)).ToListAsync();
        }

        public async Task<List<int>?> GetRoutesIDByPointsDateAsync(RouteDTO routeDTO) =>
            await _context.Routes
                .Where(r => r.DeparturePoint == routeDTO.DeparturePoint && r.ArrivalPoint == routeDTO.ArrivalPoint && r.DepartureDatetime == routeDTO.DepartureDateTime)
                .Select(r => r.RouteID)
                .ToListAsync();

        public async Task<List<Place>?> GetPlacesByRouteAsync(Route route)
        {
            var placesID = await GetPlacesIDByRouteAsync(route);
            return await _context.Places.Where(place => placesID.Contains(place.PlaceID)).ToListAsync();
        }

        public async Task<List<int>?> GetPlacesIDByRouteAsync(Route route) =>
            await _context.Places
                .Where(p => p.RouteID == route.RouteID)
                .Select(p => p.PlaceID)
                .ToListAsync();

        public async Task<Invoice?> GetInvoiceByIDAsync(int id) =>
            await _context.Invoices.FindAsync(id);

        public async Task<Invoice?> CreateInvoiceAsync(Invoice newInvoice)
        {
            _context.Invoices.Add(newInvoice);
            await _context.SaveChangesAsync();
            return newInvoice;
        }

        public async Task<List<Payment>?> GetPaymentsByUserAsync(User user)
        {
            var paymentsID = await GetPaymentsIDByUserAsync(user);
            return await _context.Payments.Where(payment => paymentsID.Contains(payment.PaymentID)).ToListAsync();
        }

        public async Task<List<int>?> GetPaymentsIDByUserAsync(User user) =>
            await _context.Payments
                .Where(payment => payment.UserID == user.UserID)
                .Select(payment => payment.PaymentID)
                .ToListAsync();

        public async Task<Payment?> GetPaymentByInvoiceAsync(Invoice invoice) =>
            await _context.Payments.FirstOrDefaultAsync(payment => payment.InvoiceID == invoice.InvoiceID);

        public async Task<Payment?> CreatePaymentAsync(Payment newPayment)
        {
            _context.Payments.Add(newPayment);
            await _context.SaveChangesAsync();
            return newPayment;
        }

        public async Task<OccupiedPlace?> GetOccupiedPlaceByTicketAsync(Ticket ticket) =>
            await _context.OccupiedPlaces.FirstOrDefaultAsync(occupiedPlace => occupiedPlace.TicketID == ticket.TicketID);

        public async Task<OccupiedPlace?> GetOccupiedPlaceByPlaceAsync(Place place) =>
            await _context.OccupiedPlaces.FirstOrDefaultAsync(occupiedPlace => occupiedPlace.PlaceID == place.PlaceID);
    }
} 