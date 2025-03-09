using API_V2.Users.Dto;
using API_V2.Users.Models;
using API_V2.Data;
using Microsoft.EntityFrameworkCore;

namespace API_V2.Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RegisterAsync(RegisterDto registerDto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
                throw new Exception("User already exists!");

            var user = new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = registerDto.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
