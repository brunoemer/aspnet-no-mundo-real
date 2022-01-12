using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplicacaoCinema.WebApi.Models
{
    public sealed class NovaSalaInputModel
    {
        [Required(ErrorMessage = "O nome da sala é um campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A quantidade de lugares é um campo obrigatório")]
        public int QuantidadeLugares { get; set; }

    }
}

