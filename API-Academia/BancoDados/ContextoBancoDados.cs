using Microsoft.EntityFrameworkCore;
using API_Academia.BancoDados.Entidades;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Academia.BancoDados
{
    public class ContextoBancoDados : DbContext
    {
        public DbSet<CargoEntidade> Cargo { get; set;}
        public DbSet<UsuarioEntidade> Usuario { get; set;}
        public DbSet<AvaliacaoFisicaEntidade> AvaliacaoFisica { get; set;}
        public DbSet<TreinoEntidade> Treino { get; set;}
        public DbSet<PresencaEntidade> Presenca { get; set;}

        public ContextoBancoDados(DbContextOptions<ContextoBancoDados> opcoesBanco) : base(opcoesBanco) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (IMutableForeignKey relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            List<CargoEntidade> cargos = new List<CargoEntidade>()
            {
                new CargoEntidade(){Id = 1, NomeCargo = "Administrador"},
                new CargoEntidade(){Id = 2, NomeCargo = "Treinador"},
                new CargoEntidade(){Id = 3, NomeCargo = "Aluno"}
            };

            UsuarioEntidade admin = new UsuarioEntidade()
            {
                Id = 1,
                IdCargo = 1,
                Nome = "Admin",
                Senha = "6K6CkoWLhOj6rYBKmbrz2nFoiULnRq5pNJlfkK4eq8YbB90n",
                DataCadastro = new DateTime(2025, 09, 03)
            };

            modelBuilder.Entity<CargoEntidade>().HasData(cargos);
            modelBuilder.Entity<UsuarioEntidade>().HasData(admin);

            base.OnModelCreating(modelBuilder);

        }
    }
}
