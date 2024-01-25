using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class Migration21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OplatyRekrutacyjne",
                columns: new[] { "ID", "KandydatID", "Kwota" },
                values: new object[,]
                {
                    { 10, 1, 80.0 },
                    { 11, 2, 80.0 },
                    { 12, 3, 80.0 },
                    { 13, 2, 80.0 }
                });

            migrationBuilder.InsertData(
                table: "TuryRekrutacji",
                columns: new[] { "ID", "DataOtwarcia", "DataZakonczenia", "KierunekStudiowID", "LiczbaZajetychMiejsc", "LimitPrzyjec", "MinimalnyProgPunktowy", "RodzajRekrutacji", "StatusTury", "TerminZakonczeniaPrzyjmowaniaAplikacji" },
                values: new object[] { 5, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 2, 0.0, 2, 4, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AplikacjeRekrutacyjne",
                columns: new[] { "ID", "DataZlozenia", "KandydatID", "KierunekStudiowID", "OplataRekrutacyjnaID", "Status", "TuraRekrutacjiID" },
                values: new object[,]
                {
                    { 10, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 10, 5, 3 },
                    { 11, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 11, 5, 3 },
                    { 12, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 12, 6, 3 },
                    { 13, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 13, 7, 4 }
                });

            migrationBuilder.InsertData(
                table: "WspolczynnikiRekrutacyjne",
                columns: new[] { "ID", "AplikacjaRekrutacyjnaID", "EgzaminID", "KierunekStudiowID" },
                values: new object[] { 10, 10, null, null });

            migrationBuilder.InsertData(
                table: "WspolczynnikiRekrutacyjne",
                columns: new[] { "ID", "AplikacjaRekrutacyjnaID", "EgzaminID", "KierunekStudiowID" },
                values: new object[] { 11, 11, null, null });

            migrationBuilder.InsertData(
                table: "WspolczynnikiRekrutacyjne",
                columns: new[] { "ID", "AplikacjaRekrutacyjnaID", "EgzaminID", "KierunekStudiowID" },
                values: new object[] { 12, 12, null, null });

            migrationBuilder.InsertData(
                table: "SkladoweWspRekrut",
                columns: new[] { "ID", "EgzaminID", "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut", "WspolczynnikRekrutacyjnyID" },
                values: new object[,]
                {
                    { 58, null, 70.0, 0, 1, 10 },
                    { 79, null, 70.0, 2, 0, 12 },
                    { 78, null, 70.0, 1, 0, 12 },
                    { 77, null, 70.0, 1, 1, 12 },
                    { 76, null, 70.0, 3, 1, 12 },
                    { 75, null, 70.0, 0, 0, 12 },
                    { 74, null, 70.0, 0, 1, 12 },
                    { 73, null, 230.0, null, 2, 11 },
                    { 72, null, 70.0, 2, 1, 11 },
                    { 71, null, 70.0, 2, 0, 11 },
                    { 70, null, 70.0, 1, 0, 11 },
                    { 69, null, 70.0, 1, 1, 11 },
                    { 68, null, 70.0, 3, 1, 11 },
                    { 67, null, 70.0, 0, 0, 11 },
                    { 66, null, 70.0, 0, 1, 11 },
                    { 65, null, 250.0, null, 2, 10 },
                    { 64, null, 70.0, 2, 1, 10 },
                    { 63, null, 70.0, 2, 0, 10 },
                    { 62, null, 70.0, 1, 0, 10 },
                    { 61, null, 70.0, 1, 1, 10 },
                    { 60, null, 70.0, 3, 1, 10 },
                    { 59, null, 70.0, 0, 0, 10 },
                    { 80, null, 70.0, 2, 1, 12 },
                    { 81, null, 210.0, null, 2, 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 12);
        }
    }
}
