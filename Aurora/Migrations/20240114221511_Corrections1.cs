using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class Corrections1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kandydaci_Wiadomosc_WiadomoscID",
                table: "Kandydaci");

            migrationBuilder.DropIndex(
                name: "IX_Kandydaci_WiadomoscID",
                table: "Kandydaci");

            migrationBuilder.DropColumn(
                name: "WiadomoscID",
                table: "Kandydaci");

            migrationBuilder.AddColumn<int>(
                name: "KandydatID",
                table: "Wiadomosc",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wiadomosc_KandydatID",
                table: "Wiadomosc",
                column: "KandydatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wiadomosc_Kandydaci_KandydatID",
                table: "Wiadomosc",
                column: "KandydatID",
                principalTable: "Kandydaci",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wiadomosc_Kandydaci_KandydatID",
                table: "Wiadomosc");

            migrationBuilder.DropIndex(
                name: "IX_Wiadomosc_KandydatID",
                table: "Wiadomosc");

            migrationBuilder.DropColumn(
                name: "KandydatID",
                table: "Wiadomosc");

            migrationBuilder.AddColumn<int>(
                name: "WiadomoscID",
                table: "Kandydaci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kandydaci_WiadomoscID",
                table: "Kandydaci",
                column: "WiadomoscID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kandydaci_Wiadomosc_WiadomoscID",
                table: "Kandydaci",
                column: "WiadomoscID",
                principalTable: "Wiadomosc",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
