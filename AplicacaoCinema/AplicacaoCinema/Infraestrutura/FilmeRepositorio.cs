using System;
using System.Collections.Generic;
using System.Linq;
using AplicacaoCinema.Domain;


namespace AplicacaoCinema.WebApi.Infraestrutura
{
    public sealed class FilmeRepositorio
    {
        private readonly FilmeDbContext _dbContext;
        

        public FilmeRepositorio(FilmeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Inserir(Filme novoFilme)
        {
            _dbContext.Filme.Add(novoFilme);

        }

        public Filme RecuperarPorId(Guid id)
        {
            return _dbContext
                .Filme
                .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Filme> RecuperarTodos()
        {
            return _dbContext
                   .Filme
                   .AsParallel<Filme>();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}