using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AplicacaoCinema.WebApi.Infraestrutura;
using AplicacaoCinema.Domain;
using AplicacaoCinema.WebApi.Models;
using AplicacaoCinema.Infraestrutura;

namespace AplicacaoEscolas.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {

        private readonly SessaoRepositorio _sessaoRepositorio;
        private readonly FilmeRepositorio _filmeRepositorio;
        private readonly SalaRepositorio _salaRepositorio;
        private readonly SessaoDTO _sessaoDTO;

        public SessaoController(SessaoRepositorio sessaoRepositorio)
        {
            _sessaoRepositorio = sessaoRepositorio;

        }

        [HttpPost]
        public async Task<IActionResult> InserirAsync([FromBody] NovaSessaoInputModel sessaoInputModel, CancellationToken cancellationToken)
        {
            var sessao = Sessao.Criar(sessaoInputModel.eDiaSemana, sessaoInputModel.horaInicial, Guid.Parse(sessaoInputModel.SalaId), Guid.Parse(sessaoInputModel.FilmeID), sessaoInputModel.preco);
            if (sessao.IsFailure)

                await _sessaoRepositorio.InserirAsync(sessao.Value, cancellationToken);
            await _sessaoRepositorio.CommitAsync(cancellationToken);
            return CreatedAtAction("RecuperarPorId", new { id = sessao.Value.Id }, sessao.Value.Id);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> ComprarIngressoAsync([FromBody] Sessao sessao, CancellationToken cancellationToken)
        {
            var _sessao = await _sessaoRepositorio.RecuperarPorIdAsync(sessao.Id, cancellationToken);
            if (_sessao == null)
                return NotFound();
            var _filme = await _filmeRepositorio.RecuperarPorIdAsync(_sessao.FilmeId, cancellationToken);
            if (_filme == null)
                return NotFound();
            var _sala = await _salaRepositorio.RecuperarPorIdAsync(_sessao.SalaId, cancellationToken);
            if (_sala == null)
                return NotFound();
            var _sessaoDTO = (_sessao.DiaSemana,
                              _sessao.HoraInicial,
                              _sala,
                              _filme,
                              _sessao.Preco);

            return Ok(_sessaoDTO);

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
        }

        [HttpGet()]
        public async Task<IActionResult> RecuperarTodosAsync(CancellationToken cancellationToken)
        {
            var sessoes = await _sessaoRepositorio.RecuperarTodosAsync(cancellationToken);

            return Ok(sessoes);
        }

    }
}
