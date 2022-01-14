using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AplicacaoCinema.Domain;

namespace AplicacaoCinema.WebApi.Models

{
    public sealed class NovaSessaoInputModel
    {
        [Required(ErrorMessage = "O dia da semana é um campo obrigatório")]
        public EDiaSemana eDiaSemana { get; set; }
        [Required(ErrorMessage = "A hora inicial é um campo obrigatório")]
        public Horario horaInicial { get; set; }
        [Required(ErrorMessage = "A sala de exibição é um campo obrigatório")]
        public string SalaId { get; set; }

        [Required(ErrorMessage = "O filme é um campo obrigatório")]
        public string FilmeID { get; set; }
        [Required(ErrorMessage = "O preço da sessão é um campo obrtigatório")]
        public double preco { get; set; }

    }
}

