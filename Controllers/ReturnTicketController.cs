using BusStationPlatform.Domains.Services.Contracts;
using BusStationPlatform.Domains.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BusStationPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReturnTicketController(IReturnTicketService _returnTicketService) : ControllerBase
    {
        [HttpDelete]
        [Route("ReturnTicket")]
        public async Task<IActionResult> ReturnTicketAsync([FromQuery] ReturnTicketRequestDTO returnTicketRequestDTO)
        {
            if (returnTicketRequestDTO == null || returnTicketRequestDTO.TicketID <= 0 || string.IsNullOrEmpty(returnTicketRequestDTO.Surname))
            {
                return BadRequest("Неверные данные запроса");
            }

            var result = await _returnTicketService.ReturnTicketAsync(returnTicketRequestDTO);
            
            if (result == null)
            {
                return NotFound("Билет не найден или фамилия не совпадает");
            }

            return Ok("Билет успешно возвращен");
        }
    }
}
