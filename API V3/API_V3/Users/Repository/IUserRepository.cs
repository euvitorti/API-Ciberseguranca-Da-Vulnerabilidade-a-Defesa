using API_V3.Users.Dto;
using API_V3.Users.Models;

namespace API_V3.Users.Repository
{
    public interface IUserRepository{
        Task RegisterAsync(RegisterDto registerDto);
    }
}