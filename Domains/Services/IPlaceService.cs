using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;

namespace BusStationPlatform.Domains.Services
{
    public interface IPlaceService
    {
        public Task<Place> GetPlaceByIDAsync(int id);
        public Task<Place> CreatePlaceAsync(PlaceDTO occupiedPlaceDTO);
        public Task<Place> UpdatePlaceAsync(Place occupiedPlace);
        public Task DeletePlaceAsync(int id);
    }
}
