using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Domains.EntitiesDTO
{
    public class PassengerDTO
    {
        public int UserID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Passport { get; set; }

        public Passenger ToPassenger()
        {
            return new Passenger
            {
                UserID = UserID,
                Name = Name,
                Surname = Surname,
                Passport = Passport
            };
        }

        public PassengerDTO FromPassenger(Passenger passenger)
        {
            return new PassengerDTO
            {
                UserID = passenger.UserID,
                Name = passenger.Name,
                Surname = passenger.Surname,
                Passport = passenger.Passport
            };
        }
    }
}
