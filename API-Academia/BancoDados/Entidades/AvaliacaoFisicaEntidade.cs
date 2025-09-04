using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Academia.BancoDados.Entidades
{
    public class AvaliacaoFisicaEntidade
    {
        [Key]
        public int Id { get; set; }
        public int IdAluno { get; set; }

        [ForeignKey("IdAluno")]
        public virtual UsuarioEntidade Aluno { get; set; } = null!;

        public int IdTreinador { get; set; }

        [ForeignKey("IdTreinador")]
        public virtual UsuarioEntidade Treinador { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public double Altura { get; set; }

        [Range(0, double.MaxValue)]
        public double Peso { get; set; }

        [Range(0, 100)]
        public double PercentualGordura { get; set; }

        [MaxLength(512)]
        public string? Observacao { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;

    }
}
