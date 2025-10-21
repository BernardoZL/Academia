using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Academia.BancoDados.Entidades
{
    public class TreinoEntidade
    {
        [Key]
        public int Id { get; set; }
        public int IdAluno { get; set; }

        [ForeignKey("IdAluno")]
        public virtual UsuarioEntidade Aluno { get; set; } = null!;

        public int IdTreinador { get; set; }

        [ForeignKey("IdTreinador")]
        public virtual UsuarioEntidade Treinador { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public required string Descricao { get; set; }
        public int DiaSemana { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
