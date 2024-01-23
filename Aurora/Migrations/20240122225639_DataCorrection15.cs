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
                name: "DziedzinaEgzaminuWstepnegoKierunekStudiow",
                columns: table => new
                {
                    DziedzinaID = table.Column<int>(type: "int", nullable: false),
                    KierunekStudiowID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DziedzinaEgzaminuWstepnegoKierunekStudiow", x => new { x.DziedzinaID, x.KierunekStudiowID });
                    table.ForeignKey(
                        name: "FK_DziedzinaEgzaminuWstepnegoKierunekStudiow_DziedzinaEgzaminuWstepnego_DziedzinaID",
                        column: x => x.DziedzinaID,
                        principalTable: "DziedzinaEgzaminuWstepnego",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DziedzinaEgzaminuWstepnegoKierunekStudiow_KierunkiStudiow_KierunekStudiowID",
                        column: x => x.KierunekStudiowID,
                        principalTable: "KierunkiStudiow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "DziedzinaEgzaminuWstepnego",
                keyColumn: "ID",
                keyValue: 2,
                column: "Dziedzina",
                value: "Fizyka");

            migrationBuilder.InsertData(
                table: "DziedzinaEgzaminuWstepnego",
                columns: new[] { "ID", "Dziedzina" },
                values: new object[] { 5, "Język angielski" });

            migrationBuilder.InsertData(
                table: "DziedzinaEgzaminuWstepnegoKierunekStudiow",
                columns: new[] { "DziedzinaID", "KierunekStudiowID" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "DziedzinaEgzaminuWstepnegoKierunekStudiow",
                columns: new[] { "DziedzinaID", "KierunekStudiowID" },
                values: new object[] { 5, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_KierunkiStudiow_NazwaKierunku_JezykWykladowy_PoziomStudiow_MiejsceStudiow_FormaStudiow",
                table: "KierunkiStudiow",
                columns: new[] { "NazwaKierunku", "JezykWykladowy", "PoziomStudiow", "MiejsceStudiow", "FormaStudiow" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AplikacjaRekrutacyjnaDziedzinaEgzaminuWstepnego_EgzaminyWstepneID",
                table: "AplikacjaRekrutacyjnaDziedzinaEgzaminuWstepnego",
                column: "EgzaminyWstepneID");

            migrationBuilder.CreateIndex(
                name: "IX_DziedzinaEgzaminuWstepnegoKierunekStudiow_KierunekStudiowID",
                table: "DziedzinaEgzaminuWstepnegoKierunekStudiow",
                column: "KierunekStudiowID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplikacjaRekrutacyjnaDziedzinaEgzaminuWstepnego");

            migrationBuilder.DropTable(
                name: "DziedzinaEgzaminuWstepnegoKierunekStudiow");

            migrationBuilder.DropIndex(
                name: "IX_KierunkiStudiow_NazwaKierunku_JezykWykladowy_PoziomStudiow_MiejsceStudiow_FormaStudiow",
                table: "KierunkiStudiow");

            migrationBuilder.DeleteData(
                table: "DziedzinaEgzaminuWstepnego",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "DziedzinaEgzaminuWstepnego",
                keyColumn: "ID",
                keyValue: 2,
                column: "Dziedzina",
                value: "Język polski");
        }
    }
}
