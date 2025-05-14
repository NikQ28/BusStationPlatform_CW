using BusStationPlatform.Domains.Services.Contracts;
using BusStationPlatform.Domains.Services.Contracts.Repositories;
using BusStationPlatform.Domains.ValueObjects;

namespace BusStationPlatform.Domains.Services.UseCases
{
    public class ReturnTicketService(ITicketRepository ticketRepository, IPassengerRepository passengerRepository, 
        ISeatRepository placeRepository) : IReturnTicketService
    {
        public async Task<(string? error, int? result)> ReturnTicketAsync(ReturnTicketRequest returnTicketRequest, CancellationToken token)
        {
            var ticket = await ticketRepository.GetTicketByIdAsync(returnTicketRequest.TicketId, token);
            if (ticket == null) return ($"Билет с номером {returnTicketRequest.TicketId} не найден", null);

            var occupiedSeat = await placeRepository.GetOccupiedSeatByTicketAsync(ticket, token);
            if (occupiedSeat == null) return ($"Билет с номером {returnTicketRequest.TicketId} уже возвращён", null);

            var passenger = await passengerRepository.GetPassengerByIdAsync(ticket.PassengerId, token);
            if (passenger == null) return ("Пассажир не найден", null);
            if (passenger.Surname != returnTicketRequest.Surname) return ("Фалимия пассажира введена некорректно", null);
            await placeRepository.DeleteOccupiedSeatAsync(occupiedSeat.OccupiedSeatId, token);
            return (null, await ticketRepository.DeleteTicketAsync(ticket.TicketId, token));
        }
    }
}
