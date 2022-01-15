using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicacaoCinema.Migrations
{
    public partial class primeiramigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "filme",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    sinopse = table.Column<string>(type: "varchar(500)", nullable: true),
                    duracao = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sala",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    quantidade_lugares = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sessao",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dia_semana = table.Column<string>(type: "varchar(15)", nullable: false),
                    hora_inicial = table.Column<string>(type: "varchar(5)", nullable: false),
                    SalaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sessao_filme_FilmeId",
                        column: x => x.FilmeId,
                        principalSchema: "dbo",
                        principalTable: "filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sessao_sala_SalaId",
                        column: x => x.SalaId,
                        principalSchema: "dbo",
                        principalTable: "sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingresso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingresso_sessao_SessaoId",
                        column: x => x.SessaoId,
                        principalSchema: "dbo",
                        principalTable: "sessao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_SessaoId",
                table: "Ingresso",
                column: "SessaoId");

            migrationBuilder.CreateIndex(
                name: "IX_sessao_FilmeId",
                schema: "dbo",
                table: "sessao",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_sessao_SalaId",
                schema: "dbo",
                table: "sessao",
                column: "SalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingresso");

            migrationBuilder.DropTable(
                name: "sessao",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "filme",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sala",
                schema: "dbo");
        }
    }
}
