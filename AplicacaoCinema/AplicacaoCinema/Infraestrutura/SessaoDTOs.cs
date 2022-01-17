using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoCinema.Domain;

namespace AplicacaoCinema.Infraestrutura
{
    public sealed class SessaoDTO
    {
        public SessaoDTO(Sessao sessao, Sala sala, Filme filme)
        {
            Id = sessao.Id.ToString();
            eDiaSemana = sessao.DiaSemana.ToString();
            HoraInicial = sessao.HoraInicial.ToString();
            SalaExibicao = sala.Nome;
            Filme = filme.Titulo;
            Preco = sessao.Preco;



        }

        public string Id { get; set; }
        public string eDiaSemana { get; set; }
        public string HoraInicial { get; set; }
        public string SalaExibicao { get; set; }
        public string Filme { get; set; }
        public double Preco { get; set; }
        
    }

}
