using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplicacaoCinema.WebApi.Models
{
    public sealed class NovoFilmeInputModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Tamanho inválido")]
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int Duracao { get; set; }
 
    }
}

