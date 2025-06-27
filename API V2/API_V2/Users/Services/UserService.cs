using API_V2.Users.Dto;
using API_V2.Users.Repository;
using API_V2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API_V2.Users.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;

        // Construtor injeta a dependência do repositório de usuários.
        public UserService(ApplicationDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        // Método para registrar um novo usuário, validando email e senha antes de prosseguir.
        public async Task RegisterUser(RegisterDto registerDto)
        {
            // Verifica se o email foi informado.
            if (string.IsNullOrWhiteSpace(registerDto.Email))
                throw new Exception("Email is required!");

            // // Verifica se a senha tem pelo menos 6 caracteres.
            // if (registerDto.Password.Length < 6)
            //     throw new Exception("Password must be at least 6 characters!");

            // Chama o repositório para registrar o usuário de forma assíncrona.
            await _userRepository.RegisterAsync(registerDto);
        }

        public async Task<string?> LoginAsync(LoginDTO loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == loginDto.UserName);

            if (user == null)
                return null; // Usuário não encontrado

            if (user.Password != loginDto.Password)
                return null; // Senha incorreta

            return "Login realizado com sucesso"; // Aqui você pode retornar um token depois
        }
    }
}
