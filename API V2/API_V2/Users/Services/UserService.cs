using API_V2.Users.Dto;
using API_V2.Users.Repository;
using API_V2.Users.Models;

namespace API_V2.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUser(RegisterDto registerDto)
        {
            if (string.IsNullOrWhiteSpace(registerDto.Email))
                throw new Exception("Email is required!");

            if (registerDto.Password.Length < 6)
                throw new Exception("Password must be at least 6 characters!");

            // Aqui poderiam ter mais regras de negócio
            await _userRepository.RegisterAsync(registerDto); // Chama o Repository
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}
