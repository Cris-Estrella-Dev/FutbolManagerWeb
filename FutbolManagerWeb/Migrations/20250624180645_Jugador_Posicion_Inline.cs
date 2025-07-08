using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutbolManagerWeb.Migrations
{
    /// <inheritdoc />
    public partial class Jugador_Posicion_Inline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Posiciones_PosicionId",
                table: "Jugadores");

            migrationBuilder.DropTable(
                name: "Posiciones");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_PosicionId",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "PosicionId",
                table: "Jugadores");

            migrationBuilder.AddColumn<string>(
                name: "Posicion",
                table: "Jugadores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Posicion",
                table: "Jugadores");

            migrationBuilder.AddColumn<int>(
                name: "PosicionId",
                table: "Jugadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Posiciones",
                columns: table => new
                {
                    PosicionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posiciones", x => x.PosicionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_PosicionId",
                table: "Jugadores",
                column: "PosicionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Posiciones_PosicionId",
                table: "Jugadores",
                column: "PosicionId",
                principalTable: "Posiciones",
                principalColumn: "PosicionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
