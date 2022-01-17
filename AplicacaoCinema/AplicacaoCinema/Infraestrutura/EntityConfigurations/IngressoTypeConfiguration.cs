


using AplicacaoCinema.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AplicacaoCinema.WebApi.Infraestrutura.EntityConfigurations
{
    public sealed class IngressoTypeConfiguration : IEntityTypeConfiguration<Ingresso>
    {
        public void Configure(EntityTypeBuilder<Ingresso> builder)
        {
            builder.ToTable("ingresso", "dbo");
            builder.HasKey(c => c.Id);
            
        }
    }
}