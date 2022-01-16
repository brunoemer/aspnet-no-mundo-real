using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplicacaoCinema.Models
{
    public sealed class NovoIngressoInputModel
    {

        [Required(ErrorMessage = "A sessao é um campo obrigatório")]
        public string SessaoId { get; set; }
        [Required(ErrorMessage = "A quantidade de ingressos é um campo obrigatório")]
        public int quantidadeIngressos { get; set; }
    }
}

