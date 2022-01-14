﻿using System;
using System.Collections.Generic;
using AplicacaoCinema.Domain;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoCinema.WebApi.Infraestrutura
{
    public sealed class SalaRepositorio
    {
        private readonly CinemaDbContext _cinemaDbContext;
        private readonly IConfiguration _configuracao;

        public SalaRepositorio(CinemaDbContext cinemadbContext, IConfiguration configuracao)
        {
            _cinemaDbContext = cinemadbContext;
            _configuracao = configuracao;
        }

        public async Task InserirAsync(Sala novaSala, CancellationToken cancellationToken = default)
        {
            await _cinemaDbContext.AddAsync(novaSala, cancellationToken);

        }

        public void Alterar(Sala sala)
        {
            // Nada a fazer EF CORE fazer o Tracking da Entidade quando recuperamos a mesma
        }

        public async Task<IEnumerable<Sala>> RecuperarTodosAsync(CancellationToken cancellationToken = default)
        {
            return await _cinemaDbContext
                .Sala
                .ToListAsync(cancellationToken);
        }

        public async Task<Sala> RecuperarPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _cinemaDbContext
                .Sala
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }



        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}