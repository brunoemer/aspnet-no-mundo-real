using System;
using AplicacaoCinema.Domain;
using AplicacaoCinema.WebApi.Infraestrutura;
using AplicacaoCinema.WebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace AplicacaoCinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly SalaRepositorio _salaRepositorio;

        public SalaController(SalaRepositorio salaRepositorio)
        {
            _salaRepositorio = salaRepositorio;
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] NovaSalaInputModel inputModel)
        {
            var sala = Sala.Criar(inputModel.nome, inputModel.QuantidadeLugares);
            if (sala.IsFailure)
                return BadRequest(sala.Error);
            _salaRepositorio.Inserir(sala.Value);
            _salaRepositorio.Commit();
            return CreatedAtAction(nameof(RecuperarPorId), new { id = sala.Value.Id }, sala.Value.Id);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarPorId(Guid id)
        {
            var sala = _salaRepositorio.RecuperarPorId(id);
            if (filme == null)
                return NotFound();
            return Ok(sala);

        }

        [HttpGet()]
        public IActionResult RecuperarTodos()
        {
            return Ok(_salaRepositorio.RecuperarTodos());
        }

    }
}