using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeInteligente.Migrations
{
    /// <inheritdoc />
    public partial class MudancaTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acidentes_Reportados_Usuarios_UsuarioId",
                table: "Acidentes_Reportados");

            migrationBuilder.DropIndex(
                name: "IX_Acidentes_Reportados_UsuarioId",
                table: "Acidentes_Reportados");

            migrationBuilder.DropColumn(
                name: "AcidenteId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Acidentes_Reportados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcidenteId",
                table: "Usuarios",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Acidentes_Reportados",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Acidentes_Reportados_UsuarioId",
                table: "Acidentes_Reportados",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acidentes_Reportados_Usuarios_UsuarioId",
                table: "Acidentes_Reportados",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
