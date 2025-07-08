using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutbolManagerWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddContrato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Posicion",
                table: "Jugadores");

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    ContratoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JugadorId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoCuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Frecuencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ContratoId);
                    table.ForeignKey(
                        name: "FK_Contratos_Jugadores_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_JugadorId",
                table: "Contratos",
                column: "JugadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.AddColumn<string>(
                name: "Posicion",
                table: "Jugadores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
