using Microsoft.AspNetCore.Mvc;
using BusStationPlatform.Domains.DTO;
using Route = BusStationPlatform.Domains.Entities.Route;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using BusStationPlatform.Domains.Services.Contracts;

namespace BusStationPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchRouteController(ISearchRouteService _searchRouteService) : ControllerBase
    {
        [Route("Search")]
        [HttpGet]
        public async Task<IActionResult> GetRoutesAsync([FromQuery] RouteDTO routeDTO)
        {
            var routes = await _searchRouteService.GetRoutesAsync(routeDTO);
            return routes == null ? BadRequest() : Ok(routes);
        }
    }
}
