using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeInteligente.Migrations
{
    /// <inheritdoc />
    public partial class MudancaNomeColunaMonitorAcidenteViolacao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Violacoes",
                newName: "Loc");

            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Monitor_Trafego",
                newName: "Loc");

            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Acidentes_Reportados",
                newName: "Loc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Loc",
                table: "Violacoes",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "Loc",
                table: "Monitor_Trafego",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "Loc",
                table: "Acidentes_Reportados",
                newName: "Local");
        }
    }
}
