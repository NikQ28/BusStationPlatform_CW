﻿using Microsoft.EntityFrameworkCore;

using BusStationPlatform.Domain.Entities;
using Route = BusStationPlatform.Domain.Entities.Route;
using BusStationPlatform.Domain.Services.Contracts.Repositories;

namespace BusStationPlatform.Storage
{
    public class SeatRepository(BusStationPlatformContext context) : ISeatRepository
    {
        public async Task<Seat?> GetSeatByIdAsync(int id, CancellationToken token) =>
            await context.Seat.FindAsync([id], token);

        public async Task<List<int>?> GetSeatsIdsByRouteAsync(Route route, CancellationToken token) =>
            await context.Seat
                .Where(p => p.RouteId == route.RouteId)
                .Select(p => p.SeatId)
                .ToListAsync(token);

        public async Task<List<Seat>?> GetSeatsByRouteAsync(Route route, CancellationToken token)
        {
            var seatsIds = await GetSeatsIdsByRouteAsync(route, token);
            if (seatsIds == null) return null;
            return await context.Seat.Where(seat => seatsIds.Contains(seat.SeatId)).ToListAsync(token);
        }

        public async Task<OccupiedSeat?> CreateOccupiedSeatAsync(OccupiedSeat newOccupiedSeat, CancellationToken token)
        {
            context.OccupiedSeat.Add(newOccupiedSeat);
            await context.SaveChangesAsync(token);
            return newOccupiedSeat;
        }

        public async Task<int?> DeleteOccupiedSeatAsync(int id, CancellationToken token)
        {
            var occupiedSeat = await context.OccupiedSeat.FindAsync([id], token);
            if (occupiedSeat != null)
            {
                context.Remove(occupiedSeat);
                await context.SaveChangesAsync(token);
                return id;
            }
            return null;
        }

        public async Task<OccupiedSeat?> GetOccupiedSeatByTicketAsync(Ticket ticket, CancellationToken token) =>
            await context.OccupiedSeat.FirstOrDefaultAsync(occupiedSeat => occupiedSeat.TicketId == ticket.TicketId, token);

        public async Task<OccupiedSeat?> GetOccupiedSeatBySeatAsync(Seat seat, CancellationToken token) =>
            await context.OccupiedSeat.FirstOrDefaultAsync(occupiedSeat => occupiedSeat.SeatId == seat.SeatId, token);
    }
}
