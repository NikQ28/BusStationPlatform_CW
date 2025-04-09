using Microsoft.AspNetCore.Mvc;
using BusStationPlatform.Repositories.Interfaces;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.DTO;

namespace BusStationPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthentificationController(IUserAuthentificationService _userAuthService) : ControllerBase
    {
        [HttpGet("login")]
        public async Task<IActionResult> AuthentificationAsync(UserDTO userDTO)
        {
            var user = await _userAuthService.AuthentificationAsync(userDTO);
            if (user == null) 
                return NotFound();
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> ChangePasswordAsync(UserDTO userDTO)
        {
            var user = await _userAuthService.ChangePasswordAsync(userDTO);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(User user)
        {
            var registeredUser = await _userAuthService.RegisterAsync(user);
            if (registeredUser == null)
                return BadRequest();
            return Ok(registeredUser);
        }

    }
}
