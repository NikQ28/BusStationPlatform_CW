using Microsoft.AspNetCore.Mvc;

using BusStationPlatform.Domain.ValueObjects;
using BusStationPlatform.Domain.Services.Contracts;
using BusStationPlatform.Domain.Entities;
using BusStationPlatform.Domain.Services.Contracts.Repositories;

namespace BusStationPlatform.Controllers
{
    /// <summary>
    /// Контроллер для управления бронированием мест.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController(IBookingService bookingService, IPassengerRepository passengerRepository) : ControllerBase
    {
        /// <summary>
        /// Получает свободные места по идентификатору маршрута.
        /// </summary>
        /// <param name="id">Идентификатор маршрута.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Список свободных мест.</returns>
        [HttpGet("free-seat")]
        public async Task<IActionResult> GetFreeSeatsAsync([FromQuery] int id, CancellationToken token)
        {
            if (id <= 0) return NotFound("Маршрут не найден");
            var (error, result) = await bookingService.GetFreeSeatsAsync(id, token);
            return (result == null) ? NotFound(error) : Ok(result);
        }

        /// <summary>
        /// Бронирует места для пассажиров.
        /// </summary>
        /// <param name="bookingRequest">Данные для бронирования.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Результат бронирования.</returns>
        [HttpPost("booking")]
        public async Task<IActionResult> BookingSeatAsync([FromBody] BookingRequest bookingRequest, CancellationToken token)
        {
            if (bookingRequest == null)
                return BadRequest("Запрос не может быть пустым");

            if (bookingRequest.RouteId <= 0)
                return BadRequest("Неверный идентификатор маршрута");

            if (bookingRequest.Passengers == null || bookingRequest.Passengers.Count == 0)
                return BadRequest("Список пассажиров не может быть пустым");

            if (bookingRequest.SeatsIds == null || bookingRequest.SeatsIds.Count == 0)
                return BadRequest("Список мест не может быть пустым");

            if (bookingRequest.Passengers.Count != bookingRequest.SeatsIds.Count)
                return BadRequest("Количество пассажиров должно соответствовать количеству мест");

            var savedPassengers = new List<Passenger>();
            foreach (var passenger in bookingRequest.Passengers)
            {
                var savedPassenger = await passengerRepository.CreatePassengerAsync(passenger, token);
                if (savedPassenger == null)
                    return BadRequest($"Не удалось сохранить пассажира {passenger.Name} {passenger.Surname}");
                savedPassengers.Add(savedPassenger);
            }
            bookingRequest.Passengers = savedPassengers;

            var (error, result) = await bookingService.BookingTicketsAsync(bookingRequest, token);
            if (!string.IsNullOrWhiteSpace(error)) return BadRequest(error);
            return Ok(result);
        }
    }
}
