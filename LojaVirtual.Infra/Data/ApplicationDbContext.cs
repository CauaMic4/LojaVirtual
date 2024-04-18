using LojaVirtual.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) { }

        public DbSet<VendaModel> Venda { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<VendaModel>()
                .HasKey(x => x.IdVenda);

            modelBuilder.Entity<ClienteModel>()
                .HasKey(x => x.IdCliente);

            modelBuilder.Entity<ProdutoModel>()
                .HasKey(x => x.IdProduto);

            modelBuilder.Entity<VendaModel>()
                 .Property(x => x.IdVenda)
                 .ValueGeneratedOnAdd();

            modelBuilder.Entity<ClienteModel>()
                 .Property(x => x.IdCliente)
                 .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProdutoModel>()
                 .Property(x => x.IdProduto)
                 .ValueGeneratedOnAdd();


            foreach (var relationship in modelBuilder.Model.
                GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}