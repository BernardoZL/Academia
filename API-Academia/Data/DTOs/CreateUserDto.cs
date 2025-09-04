using System.ComponentModel.DataAnnotations;

namespace API_Academia.Data.DTOs
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(512)]
        public required string Nome { get; set; }

        [Required]
        public required string Senha { get; set; }

        public int IdCargo { get; set; }
    }
}
