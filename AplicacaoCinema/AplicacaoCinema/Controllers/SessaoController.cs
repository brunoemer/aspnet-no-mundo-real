using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AplicacaoCinema.WebApi.Infraestrutura;
using AplicacaoCinema.Domain;
using AplicacaoCinema.WebApi.Models;
using AplicacaoCinema.Infraestrutura;
using AplicacaoCinema.Models;
using System.Collections.Generic;

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

        public SessaoController(SessaoRepositorio sessaoRepositorio, SalaRepositorio salaRepositorio, FilmeRepositorio filmeRepositorio)
        {
            _sessaoRepositorio = sessaoRepositorio;
            _salaRepositorio = salaRepositorio;
            _filmeRepositorio = filmeRepositorio;

        }

        // [HttpPost]
        public async Task<IActionResult> InserirAsync([FromBody] NovaSessaoInputModel sessaoInputModel, CancellationToken cancellationToken)
        {

            var _horaInicial = Horario.Criar(sessaoInputModel.horaInicial);
            if (_horaInicial.IsFailure)
                return BadRequest(_horaInicial.Error);
            if (!Guid.TryParse(sessaoInputModel.FilmeId, out var _filmeId))
                return BadRequest("Id de filme inválido");
            if (!Guid.TryParse(sessaoInputModel.SalaId, out var _salaId))
                return BadRequest("Id sa sala é inválido");

            var sessao = Sessao.Criar((EDiaSemana)sessaoInputModel.eDiaSemana, _horaInicial.Value, _salaId, _filmeId, sessaoInputModel.preco);
            if (sessao.IsFailure)
                return BadRequest(sessao.Error);
            await _sessaoRepositorio.InserirAsync(sessao.Value, cancellationToken);
            await _sessaoRepositorio.CommitAsync(cancellationToken);
            return CreatedAtAction("RecuperarPorId", new { id = sessao.Value.Id }, sessao.Value.Id);
        }

        [HttpPost]
        public async Task<IActionResult> ComprarIngressoAsync([FromBody] NovoIngressoInputModel ingressoInputModel, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(ingressoInputModel.SessaoId, out var _sessaoId))
                return BadRequest("Id de filme inválido");
            var _sessao = await _sessaoRepositorio.RecuperarPorIdAsync(_sessaoId, cancellationToken);
            
            List<IngressoDTO> _ingressosDTO = new List<IngressoDTO>();

            var _sala = await _salaRepositorio.RecuperarPorIdAsync(_sessao.SalaId);

            var _filme = await _filmeRepositorio.RecuperarPorIdAsync(_sessao.FilmeId, cancellationToken);

            _sessao = await _sessaoRepositorio.RecuperarTodosIngressosAsync(_sessaoId);

            int _ingressosSolicitados = ingressoInputModel.quantidadeIngressos;

            int _lugaresOcupados = _sessao.VerificarLotacaoSessao(_sessao.Ingressos);

            int _lotacaoMaximaSala = _sala.QuantidadeLugares;

            int _lugaresDisponiveis = _lotacaoMaximaSala - _lugaresOcupados;

            if (_ingressosSolicitados <= 0)
                return BadRequest("Insira um valor maior que zero");


            if (_lugaresDisponiveis > _ingressosSolicitados)
            {
                for (int i = 1; i <= ingressoInputModel.quantidadeIngressos; i++)
                {

                    _sessao.AdicionarIngresso(_sessao);
                    _ingressosDTO.Add(new IngressoDTO(_sessao, _sala, _filme));

                }

            }
            else
            {
                return Ok("Quantidade indisponível. Quantidade restante:" + _lugaresDisponiveis);
            }
            _sessaoRepositorio.Alterar(_sessao);
            return Ok(_ingressosDTO);

        }

        private IActionResult OK(IActionResult ingressosDTO)
        {
            throw new NotImplementedException();
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
