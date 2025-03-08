// using AP2_V2.Users.Dto;
// using AP2_V2.Users.Models;
// using AP2_V2.Users.Repository;
// using API_V2.Data;
// using Microsoft.EntityFrameworkCore;

// namespace AP2_V2.Users.Services
// {
//     public class UserService : IUserRepository
//     {
//         private readonly ApplicationDbContext applicationDbContext;

//         public UserService(ApplicationDbContext applicationDbContext)
//         {
//             this.applicationDbContext = applicationDbContext;
//         }

//         public async Task RegisterAsync(RegisterDto registerDto)
//         {
//             if (await applicationDbContext.Users.AnyAsync(u => u.Email == registerDto.Email))
//                 throw new Exception("User exists in our system.");

//             var user = new User
//             {
//                 Name = registerDto.Name,
//                 Password = registerDto.Password,
//                 Email = registerDto.Email
//             };

//             applicationDbContext.Users.Add(user);
//             await applicationDbContext.SaveChangesAsync();
//         }
//     }
// }