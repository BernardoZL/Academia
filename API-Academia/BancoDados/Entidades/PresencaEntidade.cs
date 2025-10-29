using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Academia.BancoDados.Entidades
{
    public class PresencaEntidade
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        //public int IdTreino { get; set; }

        //[ForeignKey("IdTreino")]
        //public virtual TreinoEntidade Treino { get; set; } = null!;

        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual UsuarioEntidade Usuario { get; set; } = null!;
    }
}
