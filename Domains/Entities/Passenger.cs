namespace BusStationPlatform.Domains.Entities
{
    /// <summary>
    /// Представляет пассажира.
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Уникальный идентификатор пассажира.
        /// </summary>
        public int PassengerID { get; set; }

        /// <summary>
        /// Идентификатор пользователя, связанного с пассажиром.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Имя пассажира.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Фамилия пассажира.
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Номер паспорта пассажира.
        /// </summary>
        public string? Passport { get; set; }
    }
}
