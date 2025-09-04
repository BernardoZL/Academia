using System.ComponentModel.DataAnnotations;

namespace API_Academia.BancoDados.Entidades
{
    public class CargoEntidade
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        public required string NomeCargo { get; set; }
    }
}
