using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class AddingDataAdrian2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WspolczynnikiRekrutacyjne",
                columns: new[] { "ID", "AplikacjaRekrutacyjnaID", "EgzaminID", "KierunekStudiowID" },
                values: new object[] { 9, 9, null, null });

            migrationBuilder.InsertData(
                table: "SkladoweWspRekrut",
                columns: new[] { "ID", "EgzaminID", "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut", "WspolczynnikRekrutacyjnyID" },
                values: new object[,]
                {
                    { 82, null, 60.0, 0, 1, 9 },
                    { 83, null, 75.0, 3, 1, 9 },
                    { 84, null, 80.0, 1, 1, 9 },
                    { 85, null, 100.0, 1, 0, 9 },
                    { 86, null, 50.0, 2, 0, 9 },
                    { 87, null, 45.0, 2, 1, 9 },
                    { 88, null, 90.0, 0, 0, 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 9);
        }
    }
}
