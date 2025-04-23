using Microsoft.AspNetCore.Mvc;
using BusStationPlatform.Domains.DTO;
using System.Reflection.Metadata.Ecma335;
using BusStationPlatform.Domains.Services.Contracts;

namespace BusStationPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController(IBookingService _bookingService) : ControllerBase
    {
        [Route("FreePlaces")]
        [HttpGet]
        public async Task<IActionResult> GetFreePlacesAsync([FromQuery] int routeID)
        {
            var freePlaces = await _bookingService.GetFreePlacesAsync(routeID);
            return freePlaces == null ? BadRequest("Нет свободных мест!") : Ok(freePlaces);
        }

        [Route("Booking")]
        [HttpPost]
        public async Task<IActionResult> BookPlaces([FromQuery] BookingRequestDTO requestDTO)
        {
            var invoice = await _bookingService.BookTicketsAsync(requestDTO);
            return invoice == null ? BadRequest() : Ok(invoice);
        }


    }
}
