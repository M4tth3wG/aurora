using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrection6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 3,
                column: "OplataRekrutacyjnaID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 4,
                column: "OplataRekrutacyjnaID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 5,
                column: "OplataRekrutacyjnaID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 6,
                column: "OplataRekrutacyjnaID",
                value: 6);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 7,
                column: "OplataRekrutacyjnaID",
                value: 7);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 8,
                column: "OplataRekrutacyjnaID",
                value: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 3,
                column: "OplataRekrutacyjnaID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 4,
                column: "OplataRekrutacyjnaID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 5,
                column: "OplataRekrutacyjnaID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 6,
                column: "OplataRekrutacyjnaID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 7,
                column: "OplataRekrutacyjnaID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 8,
                column: "OplataRekrutacyjnaID",
                value: 2);
        }
    }
}
