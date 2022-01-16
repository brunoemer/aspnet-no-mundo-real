using System;
using System.Collections.Generic;
using AplicacaoCinema.Domain;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoCinema.WebApi.Infraestrutura
{
    public sealed class SessaoRepositorio
    {
        private readonly CinemaDbContext _cinemaDbContext;
        private readonly IConfiguration _configuracao;

        public SessaoRepositorio(CinemaDbContext cinemadbContext, IConfiguration configuracao)
        {
            _cinemaDbContext = cinemadbContext;
            _configuracao = configuracao;
        }

        public async Task InserirAsync(Sessao novaSessao, CancellationToken cancellationToken = default)
        {
            await _cinemaDbContext.AddAsync(novaSessao, cancellationToken);

        }

        public void Alterar(Sessao sessao)
        {
            // Nada a fazer EF CORE fazer o Tracking da Entidade quando recuperamos a mesma
        }

        public async Task<IEnumerable<Sessao>> RecuperarTodosAsync(CancellationToken cancellationToken = default)
        {
            return await _cinemaDbContext
                .Sessao
                .ToListAsync(cancellationToken);
        }
        public async Task<Sessao> RecuperarPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _cinemaDbContext
                .Sessao
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<Sessao> RecuperarTodosIngressosAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _cinemaDbContext
                .Sessao
                .Include(c => c.Ingressos)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        



        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}