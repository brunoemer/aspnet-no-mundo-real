using System;
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

        public Filme RecuperarPorId(string id)
        {
            return _dbContext
                .Filme
                .FirstOrDefault(c => c.Id == id);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}