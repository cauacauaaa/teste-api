using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeInteligente.Migrations
{
    /// <inheritdoc />
    public partial class AddMonitorSemaforoViolacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonitorId",
                table: "Acidentes_Reportados",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Dados_Semaforo",
                columns: table => new
                {
                    SemaforoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Duracao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dados_Semaforo", x => x.SemaforoId);
                });

            migrationBuilder.CreateTable(
                name: "Monitor_Trafego",
                columns: table => new
                {
                    MonitorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataHora = table.Column<DateTime>(type: "date", nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ContagemVeiculos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VelocidadeMedia = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitor_Trafego", x => x.MonitorId);
                });

            migrationBuilder.CreateTable(
                name: "Violacoes",
                columns: table => new
                {
                    ViolacaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataOcorrencia = table.Column<DateTime>(type: "date", nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Placa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MonitorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violacoes", x => x.ViolacaoId);
                    table.ForeignKey(
                        name: "FK_Violacoes_Monitor_Trafego_MonitorId",
                        column: x => x.MonitorId,
                        principalTable: "Monitor_Trafego",
                        principalColumn: "MonitorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acidentes_Reportados_MonitorId",
                table: "Acidentes_Reportados",
                column: "MonitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Violacoes_MonitorId",
                table: "Violacoes",
                column: "MonitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acidentes_Reportados_Monitor_Trafego_MonitorId",
                table: "Acidentes_Reportados",
                column: "MonitorId",
                principalTable: "Monitor_Trafego",
                principalColumn: "MonitorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acidentes_Reportados_Monitor_Trafego_MonitorId",
                table: "Acidentes_Reportados");

            migrationBuilder.DropTable(
                name: "Dados_Semaforo");

            migrationBuilder.DropTable(
                name: "Violacoes");

            migrationBuilder.DropTable(
                name: "Monitor_Trafego");

            migrationBuilder.DropIndex(
                name: "IX_Acidentes_Reportados_MonitorId",
                table: "Acidentes_Reportados");

            migrationBuilder.DropColumn(
                name: "MonitorId",
                table: "Acidentes_Reportados");
        }
    }
}
