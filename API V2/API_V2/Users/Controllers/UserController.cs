using API_V2.Users.Dto;
using API_V2.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_V2.Users.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                await _userService.RegisterUser(registerDto); // Aqui chamamos o Service
                return Ok(new { message = "User registered successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
