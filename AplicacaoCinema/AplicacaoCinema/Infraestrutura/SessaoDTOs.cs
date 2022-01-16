using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoCinema.Domain;

namespace AplicacaoCinema.Infraestrutura
{
    public sealed class SessaoDTO
    {
        public SessaoDTO(Sessao sessao)
        {
            Sessao = sessao;
        }

        public string Id { get; set; }
        public EDiaSemana eDiaSemana { get; set; }
        public Horario HoraInicial { get; set; }
        public SalaDTO SalaExibicao { get; set; }
        public int QuantidadeVagas { get; set; }
        public FilmeDTO Filme { get; set; }
        public double Preco { get; set; }
        public Sessao Sessao { get; }
    }

    public class FilmeDTO
    {
        public string TituloFilme { get; set; }
        public string SinopseFilme { get; set; }
        public int DuracaoFilme { get; set; }
    }

    public class SalaDTO
    {
        public string NomeSala { get; set; }
        public int QuantidadeLugares { get; set; }

    }



  

}
