using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrection15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AplikacjaRekrutacyjnaDziedzinaEgzaminuWstepnego",
                columns: table => new
                {
                    AplikacjeRekrutacyjneID = table.Column<int>(type: "int", nullable: false),
                    EgzaminyWstepneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikacjaRekrutacyjnaDziedzinaEgzaminuWstepnego", x => new { x.AplikacjeRekrutacyjneID, x.EgzaminyWstepneID });
                    table.ForeignKey(
                        name: "FK_AplikacjaRekrutacyjnaDziedzinaEgzaminuWstepnego_AplikacjeRekrutacyjne_AplikacjeRekrutacyjneID",
                        column: x => x.AplikacjeRekrutacyjneID,
                        principalTable: "AplikacjeRekrutacyjne",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AplikacjaRekrutacyjnaDziedzinaEgzaminuWstepnego_DziedzinaEgzaminuWstepnego_EgzaminyWstepneID",
                        column: x => x.EgzaminyWstepneID,
                        principalTable: "DziedzinaEgzaminuWstepnego",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_AplikacjaRekrutacyjnaDziedzinaEgzaminuWstepnego_EgzaminyWstepneID",
                table: "AplikacjaRekrutacyjnaDziedzinaEgzaminuWstepnego",
                column: "EgzaminyWstepneID");

            migrationBuilder.CreateIndex(
                name: "IX_DziedzinaEgzaminuWstepnegoTuraRekrutacji_TuryID",
                table: "DziedzinaEgzaminuWstepnegoTuraRekrutacji",
                column: "TuryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplikacjaRekrutacyjnaDziedzinaEgzaminuWstepnego");

            migrationBuilder.DropTable(
                name: "DziedzinaEgzaminuWstepnegoTuraRekrutacji");
        }
    }
}
