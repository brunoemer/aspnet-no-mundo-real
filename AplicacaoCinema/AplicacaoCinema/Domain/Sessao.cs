using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using CSharpFunctionalExtensions;
using System.Linq;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;

namespace AplicacaoCinema.Domain
{
    public sealed class Sessao
    {

        private IList<Ingresso> _ingresso;
        private string _HashConcorrencia;
        private Sessao() { }

        private Sessao(Guid id, EDiaSemana diaSemana, Horario horaInicial, Guid salaId, Guid filmeId, double preco, List<Ingresso> ingressos, string hashConcorrencia)
        {
            Id = id;
            DiaSemana = diaSemana;
            HoraInicial = horaInicial;
            SalaId = salaId;
            FilmeId = filmeId;
            Preco = preco;
            _ingresso = ingressos;
            _HashConcorrencia = hashConcorrencia;

        }

        public Guid Id { get; }
        public EDiaSemana DiaSemana { get; }
        public Horario HoraInicial { get; }
        public Guid SalaId { get; }
        public Guid FilmeId { get; }
        public IEnumerable<Ingresso> Ingressos => _ingresso;
        public double Preco { get; }






        public static Result<Sessao> Criar(EDiaSemana diaSemana, Horario horaInicial, Guid salaId, Guid filmeId, double preco)
        {
            var _diaSemana = EDiaSemana.Quarta;
            if (!Enum.IsDefined(_diaSemana))
                return Result.Failure<Sessao>("É preciso definir um dia da semana");
            if (double.IsNaN(preco))
                return Result.Failure<Sessao>("O preço da sessão é um campo obrigatório");
            var sessao = new Sessao(Guid.NewGuid(), diaSemana, horaInicial, salaId, filmeId, preco, new List<Ingresso>(), "");
            sessao.AtualizarHashConcorrencia();
            return sessao;
        }

        public int VerificarLotacaoSessao(IEnumerable<Ingresso> Ingressos)
        {
            var lotacao = Ingressos.Count();
            return lotacao;

        }

        public Ingresso AdicionarIngresso(Sessao sessao)
        {
            var ingresso = Ingresso.CriarIngresso(Guid.NewGuid(), sessao);

            _ingresso.Add(ingresso);

            return ingresso;
        }

       

    public void RemoverIngresso(IEnumerable<Guid> Ingresso)
    {
        //var ingresso = _ingresso.Where(c => Ingresso.Any(id => id == c.Id));
        //   _ingresso.Remove(ingresso);
    }

    /**public void AtualizarAgenda(Guid id, EDiaSemana diaSemana, Horario horaInicial, Horario horaFinal)
    {
        var agenda = _agenda.FirstOrDefault(c => c.Id == id);
        if (agenda != null)
            agenda = new Agenda(id, diaSemana, horaInicial, horaFinal);
    }*/



    private void AtualizarHashConcorrencia()
    {
        using var hash = MD5.Create();
        var data = hash.ComputeHash(
            Encoding.UTF8.GetBytes(
                $"{Id}{DiaSemana}{HoraInicial}{SalaId}{FilmeId}{Preco}"));
        var sBuilder = new StringBuilder();
        foreach (var tbyte in data)
            sBuilder.Append(tbyte.ToString("x2"));
        _HashConcorrencia = sBuilder.ToString();
    }
}
}
