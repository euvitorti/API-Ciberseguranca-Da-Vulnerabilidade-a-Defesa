using API_V2.Users.Dto;
using API_V2.Users.Models;

namespace API_V2.Users.Services
{
    public interface IUserService
    {
        Task RegisterUser(RegisterDto registerDto);
        // Task<List<User>> GetAllUsersAsync();
    }
}