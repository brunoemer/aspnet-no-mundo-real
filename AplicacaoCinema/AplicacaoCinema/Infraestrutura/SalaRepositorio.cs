using System;
using System.Collections.Generic;
using System.Linq;
using AplicacaoCinema.Domain;


namespace AplicacaoCinema.WebApi.Infraestrutura
{
    public sealed class SalaRepositorio
    {
        private readonly SalaDbContext _dbContext;


        public SalaRepositorio(SalaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Inserir(Sala novaSala)
        {
            _dbContext.Sala.Add(novaSala);

        }

        public Sala RecuperarPorId(Guid id)
        {
            return _dbContext
                .Sala
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Sala> RecuperarTodos()
        {
            return _dbContext
                   .Sala
                   .AsParallel<Sala>();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}