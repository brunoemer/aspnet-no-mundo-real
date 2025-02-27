﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoEscolas.WebApi.Models;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace AplicacaoEscolas.WebApi.Infraestrutura
{
    public sealed class TurmasRepositorio
    {
        private readonly IConfiguration _configuracao;


        public TurmasRepositorio(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public void Inserir(Turma turma)
        {
            using (SqlConnection connection = new SqlConnection(_configuracao.GetConnectionString("Escolas")))
            {
                var comando = new SqlCommand(
                    $"INSERT INTO Turmas (Id, Descricao) VALUES ('{turma.Id}','{turma.Descricao}')", connection);
                connection.Open();
                var resutlado = comando.ExecuteNonQuery();
            }
        }

        public IEnumerable<Turma> RecuperarTodos()
        {
            using (SqlConnection connection = new SqlConnection(_configuracao.GetConnectionString("Escolas")))
            {
                var lista = connection.Query<Turma>(@"SELECT 
                                                                Turmas.Id, 
                                                                Turmas.Descricao                                                 
                                                        FROM Turmas
                                                        JOIN TurmasAgenda");


                return lista;
            }
        }
    }
}
