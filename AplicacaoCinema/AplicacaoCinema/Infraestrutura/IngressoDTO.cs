using AplicacaoCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoCinema.Infraestrutura
{
    public class IngressoDTO
    {
        public IngressoDTO(Sessao sessao, Sala sala, Filme filme )
        {
            eDiaSemana = sessao.DiaSemana;
            HoraInicial = sessao.HoraInicial;
            SalaExibicao = sala.Nome;
            NomeFilme = filme.Titulo;
            Preco = sessao.Preco;

        }

        public EDiaSemana eDiaSemana { get; set; }
        public Horario HoraInicial { get; set; }
        public string SalaExibicao { get; set; }
        public string NomeFilme { get; set; }
        public double Preco { get; set; }
      }

}

