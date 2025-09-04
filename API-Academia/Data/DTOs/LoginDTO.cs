using System.ComponentModel.DataAnnotations;

namespace API_Academia.Data.DTOs
{
    public class LoginDTO
    {
        [Required]
        public required string Login { get; set; }

        [Required]
        public required string Senha { get; set; }
    }
}
