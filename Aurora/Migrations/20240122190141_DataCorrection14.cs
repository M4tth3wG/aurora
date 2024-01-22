using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrection14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DziedzinaEgzaminuWstepnego",
                columns: new[] { "ID", "Dziedzina" },
                values: new object[,]
                {
                    { 1, "Matematyka" },
                    { 2, "Język polski" },
                    { 3, "Chemia" },
                    { 4, "Biologia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DziedzinaEgzaminuWstepnego",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DziedzinaEgzaminuWstepnego",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DziedzinaEgzaminuWstepnego",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DziedzinaEgzaminuWstepnego",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
