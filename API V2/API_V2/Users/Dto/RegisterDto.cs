using System.ComponentModel.DataAnnotations;

namespace API_V2.Users.Dto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "User's name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "User's password is required.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "User's email is required")]
        [EmailAddress(ErrorMessage = "Email format invalid.")]
        public string Email { get; set; } = string.Empty;
    }
}