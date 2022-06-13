using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InformacionCiudades.API.Migrations
{
    public partial class agregarTipoDePunto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPuntoDeInteres",
                table: "PuntosDeInteres",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 1,
                column: "TipoPuntoDeInteres",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 2,
                column: "TipoPuntoDeInteres",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 3,
                column: "TipoPuntoDeInteres",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 4,
                column: "TipoPuntoDeInteres",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 5,
                column: "TipoPuntoDeInteres",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PuntosDeInteres",
                keyColumn: "Id",
                keyValue: 6,
                column: "TipoPuntoDeInteres",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPuntoDeInteres",
                table: "PuntosDeInteres");
        }
    }
}
