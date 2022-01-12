using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplicacaoCinema.WebApi.Models
{
    public sealed class NovoFilmeInputModel
    {
        [Required(ErrorMessage ="O título é um campo obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "A sinopse do filme é um campo obrigatório")]
        public string Sinopse { get; set; }
        [Required(ErrorMessage = "A duração do filme é um campo obrigatório")]
        public int Duracao { get; set; }
 
    }
}

