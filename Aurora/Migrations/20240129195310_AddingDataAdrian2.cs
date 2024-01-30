using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class AddingDataAdrian2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WspolczynnikiRekrutacyjne",
                columns: new[] { "ID", "AplikacjaRekrutacyjnaID", "EgzaminID", "KierunekStudiowID" },
                values: new object[] { 9, 9, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WspolczynnikiRekrutacyjne",
                keyColumn: "ID",
                keyValue: 9);
        }
    }
}
