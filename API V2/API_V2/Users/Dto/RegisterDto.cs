using System.ComponentModel.DataAnnotations;

namespace AP2_V2.Users.Dto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; } = string.Empty;
    }
}