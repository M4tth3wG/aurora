using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrection1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "FormaStudiow", "MiejsceStudiow", "PoziomStudiow" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "FormaStudiow", "MiejsceStudiow", "PoziomStudiow" },
                values: new object[] { 0, 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "FormaStudiow", "MiejsceStudiow", "PoziomStudiow" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "FormaStudiow", "MiejsceStudiow", "PoziomStudiow" },
                values: new object[] { 1, 1, 1 });
        }
    }
}
