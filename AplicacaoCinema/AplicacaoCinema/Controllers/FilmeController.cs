using System;
using System.Threading;
using System.Threading.Tasks;
using AplicacaoCinema.Domain;
using AplicacaoCinema.Models;
using AplicacaoCinema.WebApi.Infraestrutura;
using AplicacaoCinema.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


namespace AplicacaoCinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly ILogger<FilmeController> _logger;
        private readonly FilmeRepositorio _filmeRepositorio;

        public FilmeController(ILogger<FilmeController> logger, FilmeRepositorio filmeRepositorio)
        {
            _logger = logger;
            _filmeRepositorio = filmeRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> IncluirAsync([FromBody] NovoFilmeInputModel inputModel, CancellationToken cancellationToken)
        {

            var filme = Filme.Criar(inputModel.Titulo, inputModel.Sinopse, inputModel.Duracao);
            if (filme.IsFailure)
                return BadRequest(filme.Error);

            _logger.LogInformation("Filme {filme} criado em memória", filme.Value.Id);

            await _filmeRepositorio.InserirAsync(filme.Value, cancellationToken);
            await _filmeRepositorio.CommitAsync(cancellationToken);
            return CreatedAtAction(nameof(RecuperarPorId), new { id = filme.Value.Id }, filme.Value.Id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarPorId(Guid id, CancellationToken cancellationToken)
        {
            var filme = await _filmeRepositorio.RecuperarPorIdAsync(id, cancellationToken);

            return Ok(filme);
        }


        [HttpGet()]
        public async Task<IActionResult> RecuperarTodosAsync(CancellationToken cancellationToken)
        {
            var filme = await _filmeRepositorio.RecuperarTodosAsync( cancellationToken);

            return Ok(filme);
        }

        /**[HttpPut()]
        public async Task<IActionResult> AlterarFilme([FromBody] AlterarFilmeInputModel alterarFilmeInputModel, CancellationToken cancellationToken)
        {
           var id = Guid.Parse(alterarFilmeInputModel.Id);
            var filme = await _filmeRepositorio.RecuperarPorIdAsync(id, cancellationToken);
            filme.Alterar(alterarFilmeInputModel.Titulo, alterarFilmeInputModel.Sinopse, alterarFilmeInputModel.Duracao);
            _filmeRepositorio.Alterar(filme);
            await _filmeRepositorio.CommitAsync(cancellationToken);
            return Ok(filme);

        }*/



    }
}