using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using BusStationPlatform.Domain.ValueObjects;
using BusStationPlatform.Domain.Services.Contracts;


namespace BusStationPlatform.Controllers
{
    /// <summary>
    /// Контроллер для поиска маршрутов.
    /// </summary>
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class SearchRouteController(ISearchRouteService searchRouteService) : ControllerBase
    {
        /// <summary>
        /// Получает маршруты по заданным параметрам поиска.
        /// </summary>
        /// <param name="routeRequest">Параметры поиска маршрута.</param>
        /// <param name="token">Токен отмены операции.</param>
        /// <returns>Список найденных маршрутов.</returns>
        [HttpGet("search-route")]
        public async Task<IActionResult> GetRoutesAsync([FromQuery] SearchRouteRequest routeRequest, CancellationToken token)
        {
            if (routeRequest == null) return BadRequest("Запрос не может быть пустым");
                  
            var (error, routes) = await searchRouteService.GetRoutesAsync(routeRequest, token);
            return (string.IsNullOrWhiteSpace(error)) ? Ok(routes) : NotFound(error);
        }
    }
}
