using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Academia.Migrations
{
    /// <inheritdoc />
    public partial class DataTreino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiaSemana",
                table: "Treino",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaSemana",
                table: "Treino");
        }
    }
}
