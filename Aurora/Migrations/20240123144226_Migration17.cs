using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class Migration17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KierunkiStudiow_NazwaKierunku_JezykWykladowy_PoziomStudiow_MiejsceStudiow_FormaStudiow",
                table: "KierunkiStudiow");

            migrationBuilder.AddColumn<double>(
                name: "LiczbaPunktow",
                table: "SkladoweWspRekrut",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 1,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 2,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 3,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 4,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 5,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 6,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 7,
                column: "LiczbaPunktow",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 8,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 9,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 10,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 11,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 12,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 13,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 14,
                column: "LiczbaPunktow",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 15,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 16,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 17,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 18,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 19,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 20,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 21,
                column: "LiczbaPunktow",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 22,
                column: "LiczbaPunktow",
                value: 60.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 23,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 24,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 25,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 26,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 27,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 28,
                column: "LiczbaPunktow",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 29,
                column: "LiczbaPunktow",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 30,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 31,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 32,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 33,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 34,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 35,
                column: "LiczbaPunktow",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 36,
                column: "LiczbaPunktow",
                value: 40.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 37,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 38,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 39,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 40,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 41,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 42,
                column: "LiczbaPunktow",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 43,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 44,
                column: "LiczbaPunktow",
                value: 65.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 45,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 46,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 47,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 48,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 49,
                column: "LiczbaPunktow",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 50,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 51,
                column: "LiczbaPunktow",
                value: 55.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 52,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 53,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 54,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 55,
                column: "LiczbaPunktow",
                value: 70.0);

            migrationBuilder.UpdateData(
                table: "SkladoweWspRekrut",
                keyColumn: "ID",
                keyValue: 56,
                column: "LiczbaPunktow",
                value: 250.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiczbaPunktow",
                table: "SkladoweWspRekrut");

            migrationBuilder.CreateIndex(
                name: "IX_KierunkiStudiow_NazwaKierunku_JezykWykladowy_PoziomStudiow_MiejsceStudiow_FormaStudiow",
                table: "KierunkiStudiow",
                columns: new[] { "NazwaKierunku", "JezykWykladowy", "PoziomStudiow", "MiejsceStudiow", "FormaStudiow" },
                unique: true);
        }
    }
}
