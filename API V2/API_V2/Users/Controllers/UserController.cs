using AP2_V2.Users.Dto;
using AP2_V2.Users.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AP2_V2.Users.Controllers
{
    [ApiController]
    [Route("api/user/")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                await _userRepository.RegisterAsync(registerDto);
                return Ok(new { message = "User added with success!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
