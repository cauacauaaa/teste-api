using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadeInteligente.Migrations
{
    /// <inheritdoc />
    public partial class MudancaDeColunaViolacaoEAcidente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dia",
                table: "Violacoes");

            migrationBuilder.DropColumn(
                name: "Loc",
                table: "Violacoes");

            migrationBuilder.DropColumn(
                name: "Dia",
                table: "Acidentes_Reportados");

            migrationBuilder.DropColumn(
                name: "Loc",
                table: "Acidentes_Reportados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Dia",
                table: "Violacoes",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Loc",
                table: "Violacoes",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dia",
                table: "Acidentes_Reportados",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Loc",
                table: "Acidentes_Reportados",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }
    }
}
