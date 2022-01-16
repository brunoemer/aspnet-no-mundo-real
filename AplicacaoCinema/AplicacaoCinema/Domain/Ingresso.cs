using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoCinema.Domain;
using CSharpFunctionalExtensions;


namespace AplicacaoCinema.Domain
{
    public class Ingresso
    {
        private Ingresso() { }

        private Ingresso(Guid id, Guid sessaoId)
        {
            Id = id;
            SessaoId = sessaoId;
        }

        public Guid Id { get; set; }
        public Guid SessaoId { get; set; }

        public static Ingresso CriarVazio() =>
                new Ingresso(Guid.Parse(""), Guid.Parse(""));
        public static Ingresso CriarIngresso(Guid id, Sessao sessao)
        {
            Ingresso _ingresso = new Ingresso(id, sessao.Id);
            return _ingresso;
        }


    }
}
