using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeInteligente.Migrations
{
    /// <inheritdoc />
    public partial class MudancaMonitorAcidenteViolacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localizacao",
                table: "Violacoes",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "DataOcorrencia",
                table: "Violacoes",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "VelocidadeMedia",
                table: "Monitor_Trafego",
                newName: "VelMedia");

            migrationBuilder.RenameColumn(
                name: "Localizacao",
                table: "Monitor_Trafego",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Monitor_Trafego",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "ContagemVeiculos",
                table: "Monitor_Trafego",
                newName: "ContVeic");

            migrationBuilder.RenameColumn(
                name: "Localizacao",
                table: "Acidentes_Reportados",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Acidentes_Reportados",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Violacoes",
                newName: "Localizacao");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Violacoes",
                newName: "DataOcorrencia");

            migrationBuilder.RenameColumn(
                name: "VelMedia",
                table: "Monitor_Trafego",
                newName: "VelocidadeMedia");

            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Monitor_Trafego",
                newName: "Localizacao");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Monitor_Trafego",
                newName: "DataHora");

            migrationBuilder.RenameColumn(
                name: "ContVeic",
                table: "Monitor_Trafego",
                newName: "ContagemVeiculos");

            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Acidentes_Reportados",
                newName: "Localizacao");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Acidentes_Reportados",
                newName: "DataHora");
        }
    }
}
