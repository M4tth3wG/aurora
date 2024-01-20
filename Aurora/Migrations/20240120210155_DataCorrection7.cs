using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrection7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RodzajDokumentu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DokumentTura",
                columns: table => new
                {
                    DokumentID = table.Column<int>(type: "int", nullable: false),
                    TuraRekrutacjiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DokumentTura", x => new { x.DokumentID, x.TuraRekrutacjiID });
                    table.ForeignKey(
                        name: "FK_DokumentTura_Dokument_DokumentID",
                        column: x => x.DokumentID,
                        principalTable: "Dokument",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DokumentTura_TuryRekrutacji_TuraRekrutacjiID",
                        column: x => x.TuraRekrutacjiID,
                        principalTable: "TuryRekrutacji",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Dokument",
                columns: new[] { "ID", "RodzajDokumentu" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 3,
                column: "LiczbaZajetychMiejsc",
                value: 3);

            migrationBuilder.InsertData(
                table: "DokumentTura",
                columns: new[] { "DokumentID", "TuraRekrutacjiID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "DokumentTura",
                columns: new[] { "DokumentID", "TuraRekrutacjiID" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "DokumentTura",
                columns: new[] { "DokumentID", "TuraRekrutacjiID" },
                values: new object[] { 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_DokumentTura_TuraRekrutacjiID",
                table: "DokumentTura",
                column: "TuraRekrutacjiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DokumentTura");

            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.UpdateData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 3,
                column: "LiczbaZajetychMiejsc",
                value: 0);
        }
    }
}
