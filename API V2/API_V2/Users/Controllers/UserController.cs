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

        // Injeta a dependência do serviço de usuário
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Endpoint para registrar um novo usuário
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                // Chama o serviço para registrar o usuário
                await _userService.RegisterUser(registerDto);
                return Ok(new { message = "User registered successfully!" });
            }
            catch (Exception ex)
            {
                // Retorna erro caso algo dê errado no processo
                return BadRequest(new { message = ex.Message });
            }
        }

        // Endpoint para buscar todos os usuários cadastrados
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
                // Retorna erro caso a busca falhe
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
