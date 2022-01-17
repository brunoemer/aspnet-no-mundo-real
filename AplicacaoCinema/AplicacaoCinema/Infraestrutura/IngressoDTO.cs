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
            eDiaSemana = sessao.DiaSemana.ToString();
            HoraInicial = sessao.HoraInicial.ToString();
            SalaExibicao = sala.Nome;
            NomeFilme = filme.Titulo;
            Preco = sessao.Preco;

        }

        public string NomeFilme { get; set; }
        public string SalaExibicao { get; set; }
        public string eDiaSemana { get; set; }
        public string HoraInicial { get; set; }
                
        public double Preco { get; set; }
      }

}

