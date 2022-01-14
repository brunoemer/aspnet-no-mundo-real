using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoCinema.Domain;

namespace AplicacaoCinema.Infraestrutura
{
    public class SessaoDTO
    {

        public Guid Id { get; set; }
        public EDiaSemana eDiaSemana { get; set; }
        public Horario HoraInicial { get; set; }
        public Sala SalaExibicao { get; set; }
        public int QuantidadeVagas { get; set; }
        public Filme Filme { get; set; }
        public double Preco { get; set; }
    }

    public class FilmeDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int Duracao { get; set; }
    }


}
