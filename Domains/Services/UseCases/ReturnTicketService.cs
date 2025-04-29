using BusStationPlatform.Domains.Services.Contracts;
using BusStationPlatform.Domains.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace BusStationPlatform.Domains.Services.UseCases
{
    public class ReturnTicketService(ITicketRepository _ticketRepository, IPassengerRepository _passengerRepository, 
        IPlaceRepository _placeRepository) : IReturnTicketService
    {
        public async Task<int?> ReturnTicketAsync(ReturnTicketRequestDTO returnTicketRequestDTO)
        {
            var ticket = await _ticketRepository.GetTicketByIDAsync(returnTicketRequestDTO.TicketID);
            if (ticket == null) return null;

            var occupiedPlace = await _placeRepository.GetOccupiedPlaceByTicketAsync(ticket);
            if (occupiedPlace == null) return null;

            await _placeRepository.DeleteOccupiedPlaceAsync(occupiedPlace.OccupiedPlaceID);

            var passenger = await _passengerRepository.GetPassengerByIDAsync(ticket.PassengerID);
            return passenger == null ? null : (passenger.Surname != returnTicketRequestDTO.Surname) ? null :
                await _ticketRepository.DeleteTicketAsync(ticket.TicketID);
        }
    }
}
