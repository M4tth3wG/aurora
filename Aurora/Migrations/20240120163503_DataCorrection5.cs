using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrection5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tresc",
                table: "Opinia",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Adresy",
                columns: new[] { "ID", "KodPocztowy", "Miejscowosc", "NumerBudynku", "Ulica" },
                values: new object[,]
                {
                    { 5, "20-230", "Lublin", "67", "Mickiewicza" },
                    { 6, "40-042", "Katowice", "15", "Wita Stwosza" }
                });

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 2,
                column: "TuraRekrutacjiID",
                value: 2);

            migrationBuilder.InsertData(
                table: "OplatyRekrutacyjne",
                columns: new[] { "ID", "KandydatID", "Kwota" },
                values: new object[,]
                {
                    { 3, 1, 80.0 },
                    { 4, 2, 80.0 },
                    { 5, 3, 80.0 },
                    { 6, 4, 80.0 }
                });

            migrationBuilder.InsertData(
                table: "TuryRekrutacji",
                columns: new[] { "ID", "DataOtwarcia", "DataZakonczenia", "KierunekStudiowID", "LiczbaZajetychMiejsc", "LimitPrzyjec", "MinimalnyProgPunktowy", "RodzajRekrutacji", "StatusTury", "TerminZakonczeniaPrzyjmowaniaAplikacji" },
                values: new object[] { 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 3, 225.0, 2, 4, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AplikacjeRekrutacyjne",
                columns: new[] { "ID", "DataZlozenia", "KandydatID", "KierunekStudiowID", "OplataRekrutacyjnaID", "Status", "TuraRekrutacjiID" },
                values: new object[,]
                {
                    { 3, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1, 5, 3 },
                    { 4, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, 5, 3 },
                    { 5, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 1, 5, 3 },
                    { 6, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 2, 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "Kandydaci",
                columns: new[] { "ID", "AdresEmail", "AdresID", "Imie", "Nazwisko", "PESEL" },
                values: new object[,]
                {
                    { 5, "karolina.nowak@example.com", 5, "Karolina", "Nowak", "12345678902" },
                    { 6, "marek.lis@example.com", 6, "Marek", "Lis", "98765432103" }
                });

            migrationBuilder.InsertData(
                table: "AplikacjeRekrutacyjne",
                columns: new[] { "ID", "DataZlozenia", "KandydatID", "KierunekStudiowID", "OplataRekrutacyjnaID", "Status", "TuraRekrutacjiID" },
                values: new object[,]
                {
                    { 7, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, 1, 6, 3 },
                    { 8, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 2, 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "OplatyRekrutacyjne",
                columns: new[] { "ID", "KandydatID", "Kwota" },
                values: new object[,]
                {
                    { 7, 5, 80.0 },
                    { 8, 6, 80.0 }
                });

            migrationBuilder.InsertData(
                table: "WspolczynnikiRekrutacyjne",
                columns: new[] { "ID", "AplikacjaRekrutacyjnaID", "egzaminID" },
                values: new object[,]
                {
                    { 3, 3, null },
                    { 4, 4, null },
                    { 5, 5, null },
                    { 6, 6, null }
                });

            migrationBuilder.InsertData(
                table: "SkladoweWspRekrut",
                columns: new[] { "ID", "EgzaminID", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut", "WspolczynnikRekrutacyjnyID" },
                values: new object[,]
                {
                    { 27, null, 2, 1, 4 },
                    { 40, null, 2, 0, 6 },
                    { 39, null, 1, 0, 6 },
                    { 38, null, 1, 1, 6 },
                    { 37, null, 3, 1, 6 },
                    { 36, null, 0, 1, 6 },
                    { 35, null, null, 2, 5 },
                    { 34, null, 2, 1, 5 },
                    { 33, null, 2, 0, 5 },
                    { 32, null, 1, 0, 5 },
                    { 31, null, 1, 1, 5 },
                    { 30, null, 3, 1, 5 },
                    { 29, null, 0, 1, 5 },
                    { 28, null, null, 2, 4 },
                    { 42, null, null, 2, 6 },
                    { 26, null, 2, 0, 4 },
                    { 25, null, 1, 0, 4 },
                    { 24, null, 1, 1, 4 },
                    { 23, null, 3, 1, 4 },
                    { 22, null, 0, 1, 4 },
                    { 21, null, null, 2, 3 },
                    { 20, null, 2, 1, 3 },
                    { 19, null, 2, 0, 3 },
                    { 18, null, 1, 0, 3 },
                    { 17, null, 1, 1, 3 },
                    { 16, null, 3, 1, 3 },
                    { 15, null, 0, 1, 3 },
                    { 41, null, 2, 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "WspolczynnikiRekrutacyjne",
                columns: new[] { "ID", "AplikacjaRekrutacyjnaID", "egzaminID" },
                values: new object[,]
                {
                    { 8, 8, null },
                    { 7, 7, null }
                });

            migrationBuilder.InsertData(
                table: "SkladoweWspRekrut",
                columns: new[] { "ID", "EgzaminID", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut", "WspolczynnikRekrutacyjnyID" },
                values: new object[,]
                {
                    { 43, null, 0, 1, 7 },
                    { 44, null, 3, 1, 7 },
                    { 45, null, 1, 1, 7 },
                    { 46, null, 1, 0, 7 },
                    { 47, null, 2, 0, 7 },
                    { 48, null, 2, 1, 7 },
                    { 49, null, null, 2, 7 },
                    { 50, null, 0, 1, 8 },
                    { 51, null, 3, 1, 8 },
                    { 52, null, 1, 1, 8 },
                    { 53, null, 1, 0, 8 },
                    { 54, null, 2, 0, 8 },
                    { 55, null, 2, 1, 8 },
                    { 56, null, null, 2, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OplatyRekrutacyjne",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Kandydaci",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kandydaci",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Tresc",
                table: "Opinia",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "AplikacjeRekrutacyjne",
                keyColumn: "ID",
                keyValue: 2,
                column: "TuraRekrutacjiID",
                value: 1);
        }
    }
}
