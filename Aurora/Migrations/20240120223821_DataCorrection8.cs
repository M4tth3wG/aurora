using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrection8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DokumentTura",
                keyColumns: new[] { "DokumentID", "TuraRekrutacjiID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DokumentTura",
                keyColumns: new[] { "DokumentID", "TuraRekrutacjiID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.CreateTable(
                name: "AplikacjaRekrutacyjnaDokument",
                columns: table => new
                {
                    DokumentID = table.Column<int>(type: "int", nullable: false),
                    AplikacjaRekrutacyjnaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikacjaRekrutacyjnaDokument", x => new { x.DokumentID, x.AplikacjaRekrutacyjnaID });
                    table.ForeignKey(
                        name: "FK_AplikacjaRekrutacyjnaDokument_AplikacjeRekrutacyjne_AplikacjaRekrutacyjnaID",
                        column: x => x.AplikacjaRekrutacyjnaID,
                        principalTable: "AplikacjeRekrutacyjne",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AplikacjaRekrutacyjnaDokument_Dokument_DokumentID",
                        column: x => x.DokumentID,
                        principalTable: "Dokument",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AplikacjaRekrutacyjnaDokument",
                columns: new[] { "AplikacjaRekrutacyjnaID", "DokumentID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Dokument",
                columns: new[] { "ID", "RodzajDokumentu" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 }
                });

            migrationBuilder.InsertData(
                table: "AplikacjaRekrutacyjnaDokument",
                columns: new[] { "AplikacjaRekrutacyjnaID", "DokumentID" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 }
                });

            migrationBuilder.InsertData(
                table: "DokumentTura",
                columns: new[] { "DokumentID", "TuraRekrutacjiID" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplikacjaRekrutacyjnaDokument_AplikacjaRekrutacyjnaID",
                table: "AplikacjaRekrutacyjnaDokument",
                column: "AplikacjaRekrutacyjnaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplikacjaRekrutacyjnaDokument");

            migrationBuilder.DeleteData(
                table: "DokumentTura",
                keyColumns: new[] { "DokumentID", "TuraRekrutacjiID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DokumentTura",
                keyColumns: new[] { "DokumentID", "TuraRekrutacjiID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DokumentTura",
                keyColumns: new[] { "DokumentID", "TuraRekrutacjiID" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "DokumentTura",
                keyColumns: new[] { "DokumentID", "TuraRekrutacjiID" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "DokumentTura",
                keyColumns: new[] { "DokumentID", "TuraRekrutacjiID" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "DokumentTura",
                keyColumns: new[] { "DokumentID", "TuraRekrutacjiID" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "DokumentTura",
                keyColumns: new[] { "DokumentID", "TuraRekrutacjiID" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "Dokument",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dokument",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dokument",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dokument",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dokument",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dokument",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dokument",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "DokumentTura",
                columns: new[] { "DokumentID", "TuraRekrutacjiID" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "DokumentTura",
                columns: new[] { "DokumentID", "TuraRekrutacjiID" },
                values: new object[] { 1, 3 });
        }
    }
}
