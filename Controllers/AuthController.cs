using Microsoft.AspNetCore.Mvc;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.IServices;

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
            if (user == null) return NotFound();
            return Ok(user);
        }

        [Route("Authentication")]
        [HttpGet]
        public async Task<IActionResult> LoginAsync([FromQuery] LoginDTO loginDTO)
        {
            var user = await _authService.LoginAsync(loginDTO);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
