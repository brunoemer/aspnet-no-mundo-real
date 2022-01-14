using System;
using System.Collections.Generic;
using AplicacaoCinema.Domain;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoCinema.WebApi.Infraestrutura
{
    public sealed class FilmeRepositorio
    {
        private readonly CinemaDbContext _cinemaDbContext;
        private readonly IConfiguration _configuracao;

        public FilmeRepositorio(CinemaDbContext cinemadbContext, IConfiguration configuracao)
        {
            _cinemaDbContext = cinemadbContext;
            _configuracao = configuracao;
        }

        public async Task InserirAsync(Filme novoFilme, CancellationToken cancellationToken = default)
        {
            await _cinemaDbContext.AddAsync(novoFilme, cancellationToken);

        }

        public void Alterar(Filme filme)
        {
            // Nada a fazer EF CORE fazer o Tracking da Entidade quando recuperamos a mesma
        }

        public async Task<IEnumerable<Filme>> RecuperarTodosAsync(CancellationToken cancellationToken = default)
        {
            return await _cinemaDbContext
                .Filme
                .ToListAsync(cancellationToken);
        }

        public async Task<Filme> RecuperarPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _cinemaDbContext
                .Filme
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }



        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}