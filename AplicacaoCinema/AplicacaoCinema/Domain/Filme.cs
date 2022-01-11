using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using CSharpFunctionalExtensions;
namespace AplicacaoCinema.Domain
{
    public class Filme
    {
        private Filme() { }

        private Filme(Guid id, string titulo, string sinopse, int duracao)
        {
            Id = id.ToString();
            Titulo = titulo;
            Sinopse = sinopse;
            Duracao = duracao;
        }

        public string Id { get; }
        public string Titulo { get; }
        public string Sinopse { get; }
        public int Duracao { get; }

        public static Result<Filme> Criar(string titulo, string sinopse, int duracao)
        {
            if (string.IsNullOrEmpty(titulo))
                return Result.Failure<Filme>("Título deve ser preenchido");
            if (string.IsNullOrEmpty(sinopse))
                return Result.Failure<Filme>("Sinopse deve ser preenchida");
            if (duracao <= 0)
                return Result.Failure<Filme>("Duração deve ser maior que 0");
            return new Filme(Guid.NewGuid(), titulo, sinopse, duracao);
        }

    }
}
