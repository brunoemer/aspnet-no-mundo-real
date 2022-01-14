using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AplicacaoCinema.WebApi.Infraestrutura;
using AplicacaoCinema.Domain;
using AplicacaoCinema.WebApi.Models;

namespace AplicacaoEscolas.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        
        private readonly SessaoRepositorio _sessaoRepositorio;

        public SessaoController(SessaoRepositorio sessaoRepositorio)
        {
            _sessaoRepositorio = sessaoRepositorio;
        }

        /**[HttpPost]
        public async Task<IActionResult> InserirAsync([FromBody] NovaSessaoInputModel sessaoInputModel, CancellationToken cancellationToken)
        {
            var sessao = Sessao.Criar(sessaoInputModel.eDiaSemana, sessaoInputModel.horaInicial, Guid.Parse(sessaoInputModel.SalaId), Guid.Parse(sessaoInputModel.FilmeID), sessaoInputModel.preco);
            if (sessao.IsFailure)

                await _sessaoRepositorio.InserirAsync(sessao.Value, cancellationToken);
            await _sessaoRepositorio.CommitAsync(cancellationToken);
            return CreatedAtAction("RecuperarPorId", new { id = sessao.Value.Id }, sessao.Value.Id);
        }

        [HttpPost]
        public async Task<IActionResult> ComprarIngressoAsync([FromBody] Sessao sessao, CancellationToken cancellationToken)
        {
            var _sessao = await _sessaoRepositorio.RecuperarTodosAsync();

            return Ok(_sessao);

        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarPorIdAsync(string id, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(id, out var guid))
                return BadRequest("Id inválido");
            var sessao = await _sessaoRepositorio.RecuperarPorIdAsync(guid, cancellationToken);
            if (sessao == null)
                return NotFound();
            return Ok(sessao);
        }*/
    }
}
