using API_V2.Users.Dto;
using API_V2.Users.Models;

namespace API_V2.Users.Repository
{
    public interface IUserRepository{
        Task RegisterAsync(RegisterDto registerDto);
    }
}