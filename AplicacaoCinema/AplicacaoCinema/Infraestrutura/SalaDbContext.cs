using AplicacaoCinema.Domain;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoCinema.WebApi.Infraestrutura
{
    public class SalaDbContext : DbContext
    {
        public SalaDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Sala> Sala { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sala>().ToTable("Sala");
            modelBuilder.Entity<Sala>()
                .HasKey(c => c.Id); ;
            modelBuilder.Entity<Sala>()
                .Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(100)")
                .IsRequired();
            modelBuilder.Entity<Sala>()
                .Property(c => c.QuantidadeLugares)
                .HasColumnName("quantidade_lugares")
                .HasColumnType("int");
            
        }
    }
}