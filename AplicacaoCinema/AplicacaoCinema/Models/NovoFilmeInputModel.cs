using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplicacaoCinema.WebApi.Models
{
    public sealed class NovoFilmeInputModel
    {
        [Required(ErrorMessage ="O t�tulo � um campo obrigat�rio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "A sinopse do filme � um campo obrigat�rio")]
        public string Sinopse { get; set; }
        [Required(ErrorMessage = "A dura��o do filme � um campo obrigat�rio")]
        public int Duracao { get; set; }
 
    }
}

