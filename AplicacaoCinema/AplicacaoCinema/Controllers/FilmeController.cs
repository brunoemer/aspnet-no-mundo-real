using System;
using AplicacaoCinema.Domain;
using AplicacaoCinema.WebApi.Infraestrutura;
using AplicacaoCinema.WebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace AplicacaoCinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeRepositorio _filmeRepositorio;

        public FilmeController(FilmeRepositorio filmeRepositorio)
        {
            _filmeRepositorio = filmeRepositorio;
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] NovoFilmeInputModel inputModel)
        {
            var filme = Filme.Criar(inputModel.Titulo, inputModel.Sinopse, inputModel.Duracao);
            if (filme.IsFailure)
                return BadRequest(filme.Error);
            _filmeRepositorio.Inserir(filme.Value);
            _filmeRepositorio.Commit();
            return CreatedAtAction(nameof(RecuperarPorId), new { id = filme.Value.Id }, filme.Value.Id);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarPorId(string id)
        {
            return Ok(_filmeRepositorio.RecuperarPorId(id));
        }

    }
}