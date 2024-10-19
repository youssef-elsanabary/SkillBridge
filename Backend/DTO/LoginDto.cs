using System.ComponentModel.DataAnnotations;

namespace Backend.DTO
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
