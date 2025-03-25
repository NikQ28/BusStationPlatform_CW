using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.EntitiesDTO
{
    public class PlaceDTO
    {
        public int RouteID { get; set; }
        public int PlaceNumber { get; set; }
        public int SectionNumber { get; set; }

        public Place ToPlace()
        {
            return new Place
            {
                RouteID = RouteID,
                PlaceNumber = PlaceNumber,
                SectionNumber = SectionNumber
            };
        }

        public static PlaceDTO FromPlace(Place place)
        {
            return new PlaceDTO
            {
                RouteID = place.RouteID,
                PlaceNumber = place.PlaceNumber,
                SectionNumber = place.SectionNumber
            };
        }
    }
}
