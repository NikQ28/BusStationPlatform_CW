using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;

namespace BusStationPlatform.Domains.Services
{
    public interface IOccupiedPlaceService
    {
        public Task<OccupiedPlace> GetOccupiedPlaceByIDAsync(int id);
        public Task<OccupiedPlace> CreateOccupiedPlaceAsync(OccupiedPlaceDTO occupiedPlaceDTO);
        public Task<OccupiedPlace> UpdateOccupiedPlaceAsync(OccupiedPlace occupiedPlace);
        public Task DeleteOccupiedPlaceAsync(int id);
    }
}
