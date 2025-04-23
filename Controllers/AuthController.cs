using Microsoft.AspNetCore.Mvc;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Services.Contracts;

namespace BusStationPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService _authService) : ControllerBase
    {
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromQuery] User newUser)
        {
            var user = await _authService.RegisterAsync(newUser);
            return user == null ? NotFound() : Ok(user);
        }

        [Route("Authentication")]
        [HttpGet]
        public async Task<IActionResult> LoginAsync([FromQuery] LoginDTO loginDTO)
        {
            var user = await _authService.LoginAsync(loginDTO);
            return (user == null) ? NotFound() : Ok(user);
        }
    }
}
