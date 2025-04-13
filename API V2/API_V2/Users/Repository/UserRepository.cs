using API_V2.Users.Dto;
using API_V2.Users.Models;
using API_V2.Data;
using Microsoft.EntityFrameworkCore;

namespace API_V2.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        // Injeta o contexto do banco de dados
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Registra um novo usuário no banco de dados
        public async Task RegisterAsync(RegisterDto registerDto)
        {
            // Verifica se o e-mail já está cadastrado
            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
                throw new Exception("User already exists!");

            // Cria uma nova entidade de usuário
            var user = new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = registerDto.Password
            };

            _context.Users.Add(user); // Adiciona o usuário ao contexto
            await _context.SaveChangesAsync(); // Persiste as mudanças no banco de dados
        }
    }
}
