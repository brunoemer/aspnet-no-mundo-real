using System;
using AplicacaoCinema.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AplicacaoCinema.Infraestrutura.EntityConfigurations
{
    public class SalaTypeConfiguration : IEntityTypeConfiguration<Sala>
    {

        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("sala");
            builder
                .HasKey(c => c.Id); 
            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(c => c.QuantidadeLugares)
                .HasColumnName("quantidade_lugares")
                .HasColumnType("int");
            
            
            builder.Property<DateTime>("DataUltimaAlteracao");
            builder.Property<DateTime>("DataCadastro");

        }

    }
}
