using API_V2.Users.Dto;

namespace API_V2.Users.Services
{
    public interface IUserService
    {
        Task<string?> LoginAsync(LoginDTO loginDTO);
        Task RegisterUser(RegisterDto registerDto);
        // Task<List<User>> GetAllUsersAsync();
    }
}