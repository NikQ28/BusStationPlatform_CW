using BusStationPlatform.Domains.Entities;
using Route = BusStationPlatform.Domains.Entities.Route;

namespace BusStationPlatform.Domains.Services.Contracts.Repositories
{
    public interface ISeatRepository
    {
        public Task<List<Seat>?> GetSeatsByRouteAsync(Route route, CancellationToken token);

        public Task<Seat?> GetSeatByIdAsync(int id, CancellationToken token);

        public Task<OccupiedSeat?> CreateOccupiedSeatAsync(OccupiedSeat newOccupiedSeat, CancellationToken token);

        public Task<int?> DeleteOccupiedSeatAsync(int occupiedSeatID, CancellationToken token);

        public Task<OccupiedSeat?> GetOccupiedSeatByTicketAsync(Ticket ticket, CancellationToken token);

        public Task<OccupiedSeat?> GetOccupiedSeatBySeatAsync(Seat seat, CancellationToken token);
    }
}
