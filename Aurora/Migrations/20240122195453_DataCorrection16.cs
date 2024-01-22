using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrection16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DziedzinaEgzaminuWstepnegoTuraRekrutacji");

            migrationBuilder.CreateTable(
                name: "DziedzinaEgzaminuWstepnegoKierunekStudiow",
                columns: table => new
                {
                    DostepneEgzaminyWstepneID = table.Column<int>(type: "int", nullable: false),
                    KierunkiStudiowID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DziedzinaEgzaminuWstepnegoKierunekStudiow", x => new { x.DostepneEgzaminyWstepneID, x.KierunkiStudiowID });
                    table.ForeignKey(
                        name: "FK_DziedzinaEgzaminuWstepnegoKierunekStudiow_DziedzinaEgzaminuWstepnego_DostepneEgzaminyWstepneID",
                        column: x => x.DostepneEgzaminyWstepneID,
                        principalTable: "DziedzinaEgzaminuWstepnego",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DziedzinaEgzaminuWstepnegoKierunekStudiow_KierunkiStudiow_KierunkiStudiowID",
                        column: x => x.KierunkiStudiowID,
                        principalTable: "KierunkiStudiow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DziedzinaEgzaminuWstepnegoKierunekStudiow_KierunkiStudiowID",
                table: "DziedzinaEgzaminuWstepnegoKierunekStudiow",
                column: "KierunkiStudiowID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DziedzinaEgzaminuWstepnegoKierunekStudiow");

            migrationBuilder.CreateTable(
                name: "DziedzinaEgzaminuWstepnegoTuraRekrutacji",
                columns: table => new
                {
                    DostepneEgzaminyWstepneID = table.Column<int>(type: "int", nullable: false),
                    TuryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DziedzinaEgzaminuWstepnegoTuraRekrutacji", x => new { x.DostepneEgzaminyWstepneID, x.TuryID });
                    table.ForeignKey(
                        name: "FK_DziedzinaEgzaminuWstepnegoTuraRekrutacji_DziedzinaEgzaminuWstepnego_DostepneEgzaminyWstepneID",
                        column: x => x.DostepneEgzaminyWstepneID,
                        principalTable: "DziedzinaEgzaminuWstepnego",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DziedzinaEgzaminuWstepnegoTuraRekrutacji_TuryRekrutacji_TuryID",
                        column: x => x.TuryID,
                        principalTable: "TuryRekrutacji",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DziedzinaEgzaminuWstepnegoTuraRekrutacji_TuryID",
                table: "DziedzinaEgzaminuWstepnegoTuraRekrutacji",
                column: "TuryID");
        }
    }
}
