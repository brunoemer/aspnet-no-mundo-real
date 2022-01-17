using System;
using AplicacaoCinema.Domain;
using AplicacaoEscolas.WebApi.Infraestrutura.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AplicacaoCinema.Infraestrutura.EntityConfigurations
{
    public sealed class SessaoTypeConfiguration : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder.ToTable("sessao", "dbo");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DiaSemana)
                .HasConversion(new EnumToStringConverter<EDiaSemana>())
                .HasColumnType("varchar(15)")
                .HasColumnName("dia_semana");
            builder.Property(c => c.HoraInicial)
                .HasConversion(EFConversores.HorarioConverter)
                .HasColumnType("varchar(5)")
                .HasColumnName("hora_inicial");
            builder
                .HasOne<Sala>()
                .WithMany()
                .HasForeignKey(c => c.SalaId);

            builder
                .HasOne<Filme>()
                .WithMany()
                .HasForeignKey(c => c.FilmeId);
            builder
                .HasMany(c => c.Ingressos)
                .WithOne()
                .HasForeignKey("SessaoId")
                .OnDelete(DeleteBehavior.Cascade)
                .Metadata
                .PrincipalToDependent
                .SetField("_ingresso");
            builder.Property(c => c.Preco)
                .HasColumnType("decimal")
                .HasColumnName("preco");

            builder.Property("_HashConcorrencia")
                .HasColumnName("Hash")
                .HasConversion<string>()
                .IsConcurrencyToken();

            builder.Property<DateTime>("DataUltimaAlteracao");
            builder.Property<DateTime>("DataCadastro");

        }
    }
}