using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AplicacaoCinema.Models
{
    public class AlterarFilmeInputModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Sinopse { get; set; }
        [Required]
        public int Duracao { get; set; }
        
    }
}
