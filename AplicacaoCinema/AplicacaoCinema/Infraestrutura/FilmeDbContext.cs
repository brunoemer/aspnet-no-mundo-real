using AplicacaoCinema.Domain;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoCinema.WebApi.Infraestrutura
{
    public class FilmeDbContext : DbContext
    {
        public FilmeDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Filme> Filme { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>().ToTable("Filme");
            modelBuilder.Entity<Filme>()
                .HasKey(c => c.Id); ;
            modelBuilder.Entity<Filme>()
                .Property(c => c.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar(50)")
                .IsRequired();
            modelBuilder.Entity<Filme>()
                .Property(c => c.Sinopse)
                .HasColumnName("sinopse")
                .HasColumnType("Lvarchar(1000)");
            modelBuilder.Entity<Filme>().Property(c => c.Duracao)
                .HasColumnName("duracao")
                .HasColumnType("int");
        }
    }
}