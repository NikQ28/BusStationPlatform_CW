﻿using System.Text.Json.Serialization;

namespace BusStationPlatform.Domain.Entities
{
    /// <summary>
    /// Представляет пассажира.
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Уникальный идентификатор пассажира.
        /// </summary>
        [JsonIgnore] 
        public int PassengerId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, связанного с пассажиром.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Имя пассажира.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Фамилия пассажира.
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Дата рождения пассажира.
        /// </summary>
        public DateOnly BirthDate { get; set; }

        /// <summary>
        /// Номер паспорта пассажира.
        /// </summary>
        public string? Passport { get; set; }
    }
}
