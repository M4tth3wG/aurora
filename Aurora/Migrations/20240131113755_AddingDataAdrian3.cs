using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class AddingDataAdrian3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "KierunkiStudiow",
                columns: new[] { "ID", "Czesne", "CzesneDlaObcokrajowcow", "FormaStudiow", "JezykWykladowy", "MiejsceStudiow", "NazwaKierunku", "OpisKierunku", "PoziomStudiow", "StrategiaID", "Wydzial" },
                values: new object[,]
                {
                    { 4, 0.0, 1250.0, 0, 0, 0, "Informatyka techniczna", "Informatyka Techniczna: Kształtowanie Przyszłości Technologii", 3, 4, 3 },
                    { 5, 0.0, 1250.0, 1, 1, 0, "Fizyka techniczna", "Odkryj nowe oblicze fizyki", 3, 0, 9 }
                });

            migrationBuilder.InsertData(
                table: "OplatyRekrutacyjne",
                columns: new[] { "ID", "KandydatID", "Kwota" },
                values: new object[] { 14, 2, 80.0 });

            migrationBuilder.InsertData(
                table: "WspolczynnikiRekrutacyjne",
                columns: new[] { "ID", "AplikacjaRekrutacyjnaID", "EgzaminID", "KierunekStudiowID" },
                values: new object[] { 13, 13, null, null });

            migrationBuilder.InsertData(
                table: "TuryRekrutacji",
                columns: new[] { "ID", "DataOtwarcia", "DataZakonczenia", "KierunekStudiowID", "LiczbaZajetychMiejsc", "LimitPrzyjec", "MinimalnyProgPunktowy", "RodzajRekrutacji", "StatusTury", "TerminZakonczeniaPrzyjmowaniaAplikacji" },
                values: new object[] { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 5, 0.0, 2, 2, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AplikacjeRekrutacyjne",
                columns: new[] { "ID", "DataZlozenia", "KandydatID", "KierunekStudiowID", "OplataRekrutacyjnaID", "Status", "TuraRekrutacjiID" },
                values: new object[] { 14, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 14, 8, 6 });

            migrationBuilder.InsertData(
                table: "WspolczynnikiRekrutacyjne",
                columns: new[] { "ID", "AplikacjaRekrutacyjnaID", "EgzaminID", "KierunekStudiowID" },
                values: new object[] { 14, 14, null, null });

            migrationBuilder.InsertData(
                table: "SkladoweWspRekrut",
                columns: new[] { "ID", "EgzaminID", "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut", "WspolczynnikRekrutacyjnyID" },
                values: new object[,]
                {
                    { 89, null, 70.0, 0, 1, 14 },
                    { 90, null, 70.0, 0, 0, 14 },
                    { 91, null, 70.0, 3, 1, 14 },
                    { 92, null, 70.0, 1, 1, 14 },
                    { 93, null, 70.0, 1, 0, 14 },
                    { 94, null, 70.0, 2, 0, 14 },
                    { 95, null, 70.0, 2, 1, 14 },
                    { 96, null, 210.0, null, 2, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kandydaci_AdresEmail",
                table: "Kandydaci",
                column: "AdresEmail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kandydaci_AdresEmail",
                table: "Kandydaci");

            migrationBuilder.DeleteData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
