using System.ComponentModel.DataAnnotations.Schema;

namespace API_Academia.BancoDados.Entidades
{
    public class PresencaEntidade
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int IdTreino { get; set; }

        [ForeignKey("IdTreino")]
        public virtual UsuarioEntidade Treino { get; set; } = null!;
    }
}
