using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoEscolas.WebApi.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using IBM.Data.DB2.Core;

namespace AplicacaoEscolas.WebApi.Infraestrutura
{
    public sealed class TurmasRepositorioSqlServer
    {
        private readonly IConfiguration _configuracao;


        public TurmasRepositorioSqlServer(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public void Inserir(Turma turma)
        {
            using (DB2Connection connection = new DB2Connection(_configuracao.GetConnectionString("EscolasIfx")))
            {
                var comando = new DB2Command(
                    $"INSERT INTO Turmas (Id, Descricao) VALUES ('{turma.Id}','{turma.Descricao}')", connection);
                connection.Open();
                var resutlado = comando.ExecuteNonQuery();
            }
        }

        public IEnumerable<Turma> RecuperarTodos()
        {
            using (DB2Connection connection = new DB2Connection(_configuracao.GetConnectionString("EscolasIfx")))
            {
                var comando = new DB2Command(@"SELECT Turmas.Id, Turmas.Descricao                                                 
                                                        FROM Turmas"
                    , connection);
                connection.Open();
                var reader = comando.ExecuteReader();
                var listaTurmas = new List<Turma>();
                while (reader.Read())
                {

                    listaTurmas.Add(
                        new Turma()
                        {
                            Id = Guid.Parse(reader.GetString(0)),
                            Descricao = reader.GetString(1)
                        });
                }
                return listaTurmas;
            }
        }
    }
}
