using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class InitData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Adresy",
                columns: new[] { "ID", "KodPocztowy", "Miejscowosc", "NumerBudynku", "Ulica" },
                values: new object[] { 4, "50-384", "Wrocław", "4", "Plac Grunwaldzki" });

            migrationBuilder.InsertData(
                table: "Kandydaci",
                columns: new[] { "ID", "AdresEmail", "AdresID", "Imie", "Nazwisko", "PESEL" },
                values: new object[] { 4, "adam.kowalski@example.com", 4, "Adam", "Kowalski", "66677733212" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kandydaci",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Adresy",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
