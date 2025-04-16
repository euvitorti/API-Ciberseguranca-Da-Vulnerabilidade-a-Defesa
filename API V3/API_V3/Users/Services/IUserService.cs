using API_V3.Users.Dto;
using API_V3.Users.Models;

namespace API_V3.Users.Services
{
    public interface IUserService
    {
        Task RegisterUser(RegisterDto registerDto);
        // Task<List<User>> GetAllUsersAsync();
    }
}