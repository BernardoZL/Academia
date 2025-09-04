using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Academia.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCargo = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Cargo_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoFisica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    IdTreinador = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<double>(type: "float", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    PercentualGordura = table.Column<double>(type: "float", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoFisica_Usuario_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvaliacaoFisica_Usuario_IdTreinador",
                        column: x => x.IdTreinador,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTreino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presenca_Usuario_IdTreino",
                        column: x => x.IdTreino,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    IdTreinador = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treino_Usuario_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treino_Usuario_IdTreinador",
                        column: x => x.IdTreinador,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cargo",
                columns: new[] { "Id", "NomeCargo" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Treinador" },
                    { 3, "Aluno" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "DataCadastro", "IdCargo", "Nome", "Senha" },
                values: new object[] { 1, new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Admin", "6K6CkoWLhOj6rYBKmbrz2nFoiULnRq5pNJlfkK4eq8YbB90n" });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoFisica_IdAluno",
                table: "AvaliacaoFisica",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoFisica_IdTreinador",
                table: "AvaliacaoFisica",
                column: "IdTreinador");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_IdTreino",
                table: "Presenca",
                column: "IdTreino");

            migrationBuilder.CreateIndex(
                name: "IX_Treino_IdAluno",
                table: "Treino",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Treino_IdTreinador",
                table: "Treino",
                column: "IdTreinador");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdCargo",
                table: "Usuario",
                column: "IdCargo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoFisica");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "Treino");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
