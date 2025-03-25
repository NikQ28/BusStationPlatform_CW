using Microsoft.EntityFrameworkCore.Query;

namespace BusStationPlatform.Domains.Entities
{
    public class Place
    {
        public int PlaceID { get; set; }
        public int RouteID { get; set; }
        public int PlaceNumber { get; set; }
        public int SectionNumber { get; set; }
    }
}
