using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using CSharpFunctionalExtensions;
namespace AplicacaoCinema.Domain
{
    public class Sala
    {
        private Sala() { }

        private Sala(Guid id, string nome, int quantidadeLugares)
        {
            Id = id;
            Nome = nome;
            QuantidadeLugares = quantidadeLugares;
        }

        public Guid Id { get; }
        public string Nome { get; }
        public int QuantidadeLugares { get; }

        public static Result<Sala> Criar(string nome, int quantidadeLugares)
        {
            if (string.IsNullOrEmpty(nome))
                return Result.Failure<Filme>("Nome da sala deve ser preenchido");
            if (quantidadeLugares <= 0)
                return Result.Failure<Filme>("A quantidade de lugares deve ser maior que 0");
            return new Sala(Guid.NewGuid(), nome, quantidadeLugares);
        }

    }
}
