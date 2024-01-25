using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class Migration22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 10,
                column: "TuraRekrutacjiID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 11,
                column: "TuraRekrutacjiID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 12,
                column: "TuraRekrutacjiID",
                value: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 10,
                column: "TuraRekrutacjiID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 11,
                column: "TuraRekrutacjiID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 12,
                column: "TuraRekrutacjiID",
                value: 3);
        }
    }
}
