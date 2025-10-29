using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Academia.Migrations
{
    /// <inheritdoc />
    public partial class presenca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presenca_Usuario_IdTreino",
                table: "Presenca");

            migrationBuilder.RenameColumn(
                name: "IdTreino",
                table: "Presenca",
                newName: "IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Presenca_IdTreino",
                table: "Presenca",
                newName: "IX_Presenca_IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Presenca_Usuario_IdUsuario",
                table: "Presenca",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presenca_Usuario_IdUsuario",
                table: "Presenca");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Presenca",
                newName: "IdTreino");

            migrationBuilder.RenameIndex(
                name: "IX_Presenca_IdUsuario",
                table: "Presenca",
                newName: "IX_Presenca_IdTreino");

            migrationBuilder.AddForeignKey(
                name: "FK_Presenca_Usuario_IdTreino",
                table: "Presenca",
                column: "IdTreino",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
