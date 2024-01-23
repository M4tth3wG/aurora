using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class AddingStrategyControl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WspolczynnikiRekrutacyjne_Egzaminy_egzaminID",
                table: "WspolczynnikiRekrutacyjne");

            migrationBuilder.RenameColumn(
                name: "egzaminID",
                table: "WspolczynnikiRekrutacyjne",
                newName: "EgzaminID");

            migrationBuilder.RenameIndex(
                name: "IX_WspolczynnikiRekrutacyjne_egzaminID",
                table: "WspolczynnikiRekrutacyjne",
                newName: "IX_WspolczynnikiRekrutacyjne_EgzaminID");

            migrationBuilder.AddColumn<int>(
                name: "KierunekStudiowID",
                table: "WspolczynnikiRekrutacyjne",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategiaID",
                table: "KierunkiStudiow",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 1,
                column: "StrategiaID",
                value: 8);

            migrationBuilder.CreateIndex(
                name: "IX_WspolczynnikiRekrutacyjne_KierunekStudiowID",
                table: "WspolczynnikiRekrutacyjne",
                column: "KierunekStudiowID");

            migrationBuilder.AddForeignKey(
                name: "FK_WspolczynnikiRekrutacyjne_Egzaminy_EgzaminID",
                table: "WspolczynnikiRekrutacyjne",
                column: "EgzaminID",
                principalTable: "Egzaminy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WspolczynnikiRekrutacyjne_KierunkiStudiow_KierunekStudiowID",
                table: "WspolczynnikiRekrutacyjne",
                column: "KierunekStudiowID",
                principalTable: "KierunkiStudiow",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WspolczynnikiRekrutacyjne_Egzaminy_EgzaminID",
                table: "WspolczynnikiRekrutacyjne");

            migrationBuilder.DropForeignKey(
                name: "FK_WspolczynnikiRekrutacyjne_KierunkiStudiow_KierunekStudiowID",
                table: "WspolczynnikiRekrutacyjne");

            migrationBuilder.DropIndex(
                name: "IX_WspolczynnikiRekrutacyjne_KierunekStudiowID",
                table: "WspolczynnikiRekrutacyjne");

            migrationBuilder.DropColumn(
                name: "KierunekStudiowID",
                table: "WspolczynnikiRekrutacyjne");

            migrationBuilder.DropColumn(
                name: "StrategiaID",
                table: "KierunkiStudiow");

            migrationBuilder.RenameColumn(
                name: "EgzaminID",
                table: "WspolczynnikiRekrutacyjne",
                newName: "egzaminID");

            migrationBuilder.RenameIndex(
                name: "IX_WspolczynnikiRekrutacyjne_EgzaminID",
                table: "WspolczynnikiRekrutacyjne",
                newName: "IX_WspolczynnikiRekrutacyjne_egzaminID");

            migrationBuilder.AddForeignKey(
                name: "FK_WspolczynnikiRekrutacyjne_Egzaminy_egzaminID",
                table: "WspolczynnikiRekrutacyjne",
                column: "egzaminID",
                principalTable: "Egzaminy",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
