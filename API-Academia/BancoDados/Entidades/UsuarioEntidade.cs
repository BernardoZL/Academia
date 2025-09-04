using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Academia.BancoDados.Entidades
{
    public class UsuarioEntidade
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(512)]
        public required string Nome { get; set; }

        public required string Senha { get; set; }
        public int IdCargo { get; set; }

        [ForeignKey("IdCargo")]
        public virtual CargoEntidade Cargo { get; set; } = null!;

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
