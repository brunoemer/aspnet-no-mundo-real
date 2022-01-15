using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AplicacaoCinema.Domain;
using Microsoft.EntityFrameworkCore;
using AplicacaoCinema.Infraestrutura.EntityConfigurations;

namespace AplicacaoCinema.WebApi.Infraestrutura
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Filme> Filme { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Sessao> Sessao { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                foreach (var item in ChangeTracker.Entries())
                {
                    if (item.State is Microsoft.EntityFrameworkCore.EntityState.Modified or Microsoft.EntityFrameworkCore.EntityState.Added
                        && item.Properties.Any(c => c.Metadata.Name == "DataUltimaAlteracao"))
                        item.Property("DataUltimaAlteracao").CurrentValue = DateTime.UtcNow;

                    if (item.State == EntityState.Added
                        && item.Properties.Any(c => c.Metadata.Name == "DataCadastro"))
                        item.Property("DataCadastro").CurrentValue = DateTime.UtcNow;
                }
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException e)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SalaTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SessaoTypeConfiguration());

        }


    }
}