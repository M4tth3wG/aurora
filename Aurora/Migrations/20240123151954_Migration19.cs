using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class Migration19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 5,
                column: "Status",
                value: 6);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 7,
                column: "Status",
                value: 5);

            migrationBuilder.InsertData(
                table: "SkladoweWspRekrut",
                columns: new[] { "ID", "EgzaminID", "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut", "WspolczynnikRekrutacyjnyID" },
                values: new object[] { 57, null, 70.0, 0, 0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 5,
                column: "Status",
                value: 5);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 7,
                column: "Status",
                value: 6);
        }
    }
}
