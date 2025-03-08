using AP2_V2.Users.Dto;
using AP2_V2.Users.Models;
using API_V2.Data;
using Microsoft.EntityFrameworkCore;

namespace AP2_V2.Users.Repository
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
                throw new Exception("User exists in our system.");

            var user = new User
            {
                Name = registerDto.Name,
                Password = registerDto.Password,
                Email = registerDto.Email
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
