using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class Migration18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 70.0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 70.0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 70.0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 35,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 70.0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 42,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 70.0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 49,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 70.0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 56,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 70.0, 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 250.0, null, 2 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 21,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 250.0, null, 2 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 28,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 250.0, null, 2 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 35,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 250.0, null, 2 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 42,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 250.0, null, 2 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 49,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 250.0, null, 2 });

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 56,
                columns: new[] { "LiczbaPunktow", "PrzedmiotMaturalny", "RodzajSkladowejWspRekrut" },
                values: new object[] { 250.0, null, 2 });
        }
    }
}
