using API_Academia.BancoDados.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Academia.Data.DTOs
{
    public class TreinoDTO
    {
        public int? Id { get; set; }
        public int IdAluno { get; set; }
        public int IdTreinador { get; set; }

        [Required]
        [MaxLength(200)]
        public required string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
