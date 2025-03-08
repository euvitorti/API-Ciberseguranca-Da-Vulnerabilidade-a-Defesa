using AP2_V2.Users.Dto;

namespace AP2_V2.Users.Repository
{
    public interface IUserRepository{
        Task RegisterAsync(RegisterDto registerDto);
    }
}