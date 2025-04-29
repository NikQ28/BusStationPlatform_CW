using Microsoft.AspNetCore.Mvc;
using BusStationPlatform.Domains.DTO;
using System.Reflection.Metadata.Ecma335;
using BusStationPlatform.Domains.Services.Contracts;
using BusStationPlatform.Domains.Entities;

namespace BusStationPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController(IBookingService _bookingService, IPassengerRepository _passengerRepository) : ControllerBase
    {
        [Route("FreePlaces")]
        [HttpGet]
        public async Task<IActionResult> GetFreePlacesAsync([FromQuery] int routeID)
        {
            if (routeID <= 0) return BadRequest("Маршрут не найден");

            var freePlaces = await _bookingService.GetFreePlacesAsync(routeID);
            return freePlaces == null ? BadRequest("Не удалось получить информацию о свободных местах") : Ok(freePlaces);
        }

        [Route("Booking")]
        [HttpPost]
        public async Task<IActionResult> BookPlaces([FromBody] BookingRequestDTO requestDTO)
        {
            if (requestDTO == null)
                return BadRequest("Запрос не может быть пустым");

            if (requestDTO.RouteID <= 0)
                return BadRequest("Неверный идентификатор маршрута");

            if (requestDTO.Passengers == null || !requestDTO.Passengers.Any())
                return BadRequest("Список пассажиров не может быть пустым");

            if (requestDTO.PlacesID == null || !requestDTO.PlacesID.Any())
                return BadRequest("Список мест не может быть пустым");

            if (requestDTO.Passengers.Count != requestDTO.PlacesID.Count)
                return BadRequest("Количество пассажиров должно соответствовать количеству мест");

            var savedPassengers = new List<Passenger>();
            foreach (var passenger in requestDTO.Passengers)
            {
                var savedPassenger = await _passengerRepository.CreatePassengerAsync(passenger);
                if (savedPassenger == null)
                    return BadRequest($"Не удалось сохранить пассажира {passenger.Name} {passenger.Surname}");
                savedPassengers.Add(savedPassenger);
            }
            requestDTO.Passengers = savedPassengers;

            var invoice = await _bookingService.BookTicketsAsync(requestDTO);
            return invoice == null ? BadRequest("Не удалось выполнить бронирование") : Ok(invoice);
        }
    }
}
