using API_V3.Users.Dto;
using API_V3.Users.Repository;
using API_V3.Users.Models;

namespace API_V3.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // Construtor injeta a dependência do repositório de usuários.
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Método para registrar um novo usuário, validando email e senha antes de prosseguir.
        public async Task RegisterUser(RegisterDto registerDto)
        {
            // Verifica se o email foi informado.
            if (string.IsNullOrWhiteSpace(registerDto.Email))
                throw new Exception("Email is required!");

            // Verifica se a senha tem pelo menos 6 caracteres.
            if (registerDto.Password.Length < 6)
                throw new Exception("Password must be at least 6 characters!");

            // Chama o repositório para registrar o usuário de forma assíncrona.
            await _userRepository.RegisterAsync(registerDto);
        }

        // Recupera todos os usuários de forma assíncrona.
        // public async Task<List<User>> GetAllUsersAsync()
        // {
        //     return await _userRepository.GetAllUsersAsync();
        // }
    }
}
