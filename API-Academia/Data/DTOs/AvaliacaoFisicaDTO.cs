using API_Academia.BancoDados.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Academia.Data.DTOs
{
    public class AvaliacaoFisicaDTO
    {
        public int? Id { get; set; }
        public int IdAluno { get; set; }
        public int IdTreinador { get; set; }

        [Range(0, double.MaxValue)]
        public double Altura { get; set; }

        [Range(0, double.MaxValue)]
        public double Peso { get; set; }

        [Range(0, 100)]
        public double PercentualGordura { get; set; }

        [MaxLength(512)]
        public string? Observacao { get; set; }
    }
}
