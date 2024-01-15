using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class InitData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Adresy",
                columns: new[] { "ID", "KodPocztowy", "Miejscowosc", "NumerBudynku", "Ulica" },
                values: new object[] { 1, "00-001", "Warszawa", "123", "Aleje Jerozolimskie" });

            migrationBuilder.InsertData(
                table: "Adresy",
                columns: new[] { "ID", "KodPocztowy", "Miejscowosc", "NumerBudynku", "Ulica" },
                values: new object[] { 2, "30-062", "Kraków", "45", "Rynek Główny" });

            migrationBuilder.InsertData(
                table: "Adresy",
                columns: new[] { "ID", "KodPocztowy", "Miejscowosc", "NumerBudynku", "Ulica" },
                values: new object[] { 3, "80-830", "Gdańsk", "8", "Długi Targ" });

            migrationBuilder.InsertData(
                table: "Kandydaci",
                columns: new[] { "ID", "AdresEmail", "AdresID", "Imie", "Nazwisko", "PESEL" },
                values: new object[] { 3, "piotr.zalewski@example.com", 1, "Piotr", "Zalewski", "55511133344" });

            migrationBuilder.InsertData(
                table: "Kandydaci",
                columns: new[] { "ID", "AdresEmail", "AdresID", "Imie", "Nazwisko", "PESEL" },
                values: new object[] { 1, "jan.kowalski@example.com", 2, "Jan", "Kowalski", "12345678901" });

            migrationBuilder.InsertData(
                table: "Kandydaci",
                columns: new[] { "ID", "AdresEmail", "AdresID", "Imie", "Nazwisko", "PESEL" },
                values: new object[] { 2, "anna.nowak@example.com", 3, "Anna", "Nowak", "98765432109" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kandydaci",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kandydaci",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kandydaci",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
