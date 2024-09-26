using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeInteligente.Migrations
{
    /// <inheritdoc />
    public partial class MudancaNomeColunaMonitorAcidenteViolacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Violacoes",
                newName: "Dia");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Monitor_Trafego",
                newName: "Dia");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Acidentes_Reportados",
                newName: "Dia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dia",
                table: "Violacoes",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "Dia",
                table: "Monitor_Trafego",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "Dia",
                table: "Acidentes_Reportados",
                newName: "Data");
        }
    }
}
