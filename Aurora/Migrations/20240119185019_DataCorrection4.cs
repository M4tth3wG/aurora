using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrection4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TuraRekrutacjiID",
                table: "Opinia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 1,
                column: "PoziomStudiow",
                value: 2);

            migrationBuilder.UpdateData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 2,
                column: "PoziomStudiow",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Opinia_TuraRekrutacjiID",
                table: "Opinia",
                column: "TuraRekrutacjiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinia_TuryRekrutacji_TuraRekrutacjiID",
                table: "Opinia",
                column: "TuraRekrutacjiID",
                principalTable: "TuryRekrutacji",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinia_TuryRekrutacji_TuraRekrutacjiID",
                table: "Opinia");

            migrationBuilder.DropIndex(
                name: "IX_Opinia_TuraRekrutacjiID",
                table: "Opinia");

            migrationBuilder.DropColumn(
                name: "TuraRekrutacjiID",
                table: "Opinia");

            migrationBuilder.UpdateData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 1,
                column: "PoziomStudiow",
                value: 0);

            migrationBuilder.UpdateData(
                table: "KierunkiStudiow",
                keyColumn: "ID",
                keyValue: 2,
                column: "PoziomStudiow",
                value: 0);
        }
    }
}
