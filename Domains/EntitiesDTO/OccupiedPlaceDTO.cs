using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.EntitiesDTO
{
    public class OccupiedPlaceDTO
    {
        public int PlaceID { get; set; }
        public int TicketID { get; set; }


        public OccupiedPlace ToOccupiedPlace()
        {
            return new OccupiedPlace
            {
                PlaceID = PlaceID,
                TicketID = TicketID
            };
        }

        public static OccupiedPlaceDTO FromOccupiedPlace(OccupiedPlace occupiedPlace)
        {
            return new OccupiedPlaceDTO
            {
                PlaceID = occupiedPlace.PlaceID,
                TicketID = occupiedPlace.TicketID
            };
        }


    }
}
