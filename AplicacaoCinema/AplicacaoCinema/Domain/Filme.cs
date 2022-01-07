using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoCinema.Domain
{
    public class Filme
    {
        private Filme() { }

        private Filme(Guid id, string titulo, string sinopse, int duracao)
        {
            Id = id;
            Titulo = titulo;
            Sinopse = sinopse;
            Duracao = duracao;
        }

        public Guid Id { get; }
        public string Titulo { get; }
        public string Sinopse { get; }
        public int Duracao { get; }

    }
}
