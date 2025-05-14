using Microsoft.AspNetCore.Mvc;

using BusStationPlatform.Domains.Services.Contracts;
using BusStationPlatform.Domains.ValueObjects;

namespace BusStationPlatform.Controllers
{
    /// <summary>
    /// Контроллер для управления возвратом билетов.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ReturnTicketController(IReturnTicketService returnTicketService) : ControllerBase
    {
        /// <summary>
        /// Осуществляет возврат билета.
        /// </summary>
        /// <param name="returnTicketRequest">Данные для возврата билета.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Результат возврата билета.</returns>
        [HttpPost]
        [Route("return-ticket")]
        public async Task<IActionResult> ReturnTicketAsync([FromQuery] ReturnTicketRequest returnTicketRequest, CancellationToken token)
        {
            if (returnTicketRequest == null) return BadRequest("Запрос не может быть пустым"); 
            var (error, result) = await returnTicketService.ReturnTicketAsync(returnTicketRequest, token);
            return (string.IsNullOrWhiteSpace(error)) ? Ok($"Билет {result} успешно возвращен") : NotFound(error);
        }
    }
}
