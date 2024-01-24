using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class AddingDataAdrian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kandydaci",
                columns: new[] { "ID", "AdresEmail", "AdresID", "Imie", "Nazwisko", "PESEL" },
                values: new object[] { 7, "szymon.nowak@example.com", 3, "Szymon", "Nowak", "66677889900" });

            migrationBuilder.InsertData(
                table: "KierunkiStudiow",
                columns: new[] { "ID", "Czesne", "CzesneDlaObcokrajowcow", "FormaStudiow", "JezykWykladowy", "MiejsceStudiow", "NazwaKierunku", "OpisKierunku", "PoziomStudiow", "StrategiaID", "Wydzial" },
                values: new object[] { 3, 0.0, 1250.0, 0, 0, 0, "Fizyka techniczna", "Odkryj nowe oblicze fizyki", 3, 0, 9 });

            migrationBuilder.InsertData(
                table: "OplatyRekrutacyjne",
                columns: new[] { "ID", "KandydatID", "Kwota" },
                values: new object[] { 9, 2, 80.0 });

            migrationBuilder.UpdateData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 1,
                column: "MinimalnyProgPunktowy",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 2,
                column: "MinimalnyProgPunktowy",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 3,
                column: "MinimalnyProgPunktowy",
                value: 0.0);

            migrationBuilder.InsertData(
                table: "TuryRekrutacji",
                columns: new[] { "ID", "DataOtwarcia", "DataZakonczenia", "KierunekStudiowID", "LiczbaZajetychMiejsc", "LimitPrzyjec", "MinimalnyProgPunktowy", "RodzajRekrutacji", "StatusTury", "TerminZakonczeniaPrzyjmowaniaAplikacji" },
                values: new object[] { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 5, 0.0, 2, 2, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AplikacjeRekrutacyjne",
                columns: new[] { "ID", "DataZlozenia", "KandydatID", "KierunekStudiowID", "OplataRekrutacyjnaID", "Status", "TuraRekrutacjiID" },
                values: new object[] { 9, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3, 9, 8, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Kandydaci",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 1,
                column: "MinimalnyProgPunktowy",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 2,
                column: "MinimalnyProgPunktowy",
                value: 225.0);

            migrationBuilder.UpdateData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 3,
                column: "MinimalnyProgPunktowy",
                value: 225.0);
        }
    }
}
