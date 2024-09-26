using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeInteligente.Migrations
{
    /// <inheritdoc />
    public partial class RemocaoChavesEstrangeiras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acidentes_Reportados_Monitor_Trafego_MonitorId",
                table: "Acidentes_Reportados");

            migrationBuilder.DropForeignKey(
                name: "FK_Violacoes_Monitor_Trafego_MonitorId",
                table: "Violacoes");

            migrationBuilder.DropIndex(
                name: "IX_Violacoes_MonitorId",
                table: "Violacoes");

            migrationBuilder.DropIndex(
                name: "IX_Acidentes_Reportados_MonitorId",
                table: "Acidentes_Reportados");

            migrationBuilder.DropColumn(
                name: "MonitorId",
                table: "Violacoes");

            migrationBuilder.DropColumn(
                name: "MonitorId",
                table: "Acidentes_Reportados");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dia",
                table: "Violacoes",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Dia",
                table: "Acidentes_Reportados",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dia",
                table: "Violacoes");

            migrationBuilder.DropColumn(
                name: "Dia",
                table: "Acidentes_Reportados");

            migrationBuilder.AddColumn<int>(
                name: "MonitorId",
                table: "Violacoes",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonitorId",
                table: "Acidentes_Reportados",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Violacoes_MonitorId",
                table: "Violacoes",
                column: "MonitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Acidentes_Reportados_MonitorId",
                table: "Acidentes_Reportados",
                column: "MonitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acidentes_Reportados_Monitor_Trafego_MonitorId",
                table: "Acidentes_Reportados",
                column: "MonitorId",
                principalTable: "Monitor_Trafego",
                principalColumn: "MonitorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Violacoes_Monitor_Trafego_MonitorId",
                table: "Violacoes",
                column: "MonitorId",
                principalTable: "Monitor_Trafego",
                principalColumn: "MonitorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
