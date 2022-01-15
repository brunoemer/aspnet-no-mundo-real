using System;
using System.Threading;
using System.Threading.Tasks;
using AplicacaoCinema.Domain;
using AplicacaoCinema.WebApi.Infraestrutura;
using AplicacaoCinema.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AplicacaoCinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ILogger<SalaController> _logger;
        private readonly SalaRepositorio _salaRepositorio;

        public SalaController(ILogger<SalaController> logger, SalaRepositorio salaRepositorio)
        {
            _logger = logger;
            _salaRepositorio = salaRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> IncluirAsync([FromBody] NovaSalaInputModel inputModel, CancellationToken cancellationToken)
        {

            var sala = Sala.Criar(inputModel.Nome, inputModel.QuantidadeLugares);
            if (sala.IsFailure)
                return BadRequest(sala.Error);

            _logger.LogInformation("Sala {sala} criado em memória", sala.Value.Id);

            await _salaRepositorio.InserirAsync(sala.Value, cancellationToken);
            await _salaRepositorio.CommitAsync(cancellationToken);
            return CreatedAtAction(nameof(RecuperarPorId), new { id = sala.Value.Id }, sala.Value.Id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarPorId(Guid id, CancellationToken cancellationToken)
        {
            var filme = await _salaRepositorio.RecuperarPorIdAsync(id, cancellationToken);

            return Ok(filme);
        }


        [HttpGet()]
        public async Task<IActionResult> RecuperarTodosAsync(CancellationToken cancellationToken)
        {
            var filme = await _salaRepositorio.RecuperarTodosAsync(cancellationToken);

            return Ok(filme);
        }


    }
}