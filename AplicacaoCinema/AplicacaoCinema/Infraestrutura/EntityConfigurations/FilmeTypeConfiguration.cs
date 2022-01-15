using System;
using AplicacaoCinema.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AplicacaoCinema.Infraestrutura.EntityConfigurations
{
    public class FilmeTypeConfiguration : IEntityTypeConfiguration<Filme>
    {

        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("filme", "dbo");
            builder
                .HasKey(c => c.Id); 
            builder.Property(c => c.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(c => c.Sinopse)
                .HasColumnName("sinopse")
                .HasColumnType("varchar(500)");
            builder.Property(c => c.Duracao)
                .HasColumnName("duracao")
                .HasColumnType("int");

            
            builder.Property<DateTime>("DataUltimaAlteracao");
            builder.Property<DateTime>("DataCadastro");

        }

    }
}
