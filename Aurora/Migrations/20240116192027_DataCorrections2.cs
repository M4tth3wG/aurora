using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrections2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wiadomosc_Kandydaci_KandydatID",
                table: "Wiadomosc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wiadomosc",
                table: "Wiadomosc");

            migrationBuilder.RenameTable(
                name: "Wiadomosc",
                newName: "Wiadomosci");

            migrationBuilder.RenameIndex(
                name: "IX_Wiadomosc_KandydatID",
                table: "Wiadomosci",
                newName: "IX_Wiadomosci_KandydatID");

            migrationBuilder.AlterColumn<int>(
                name: "KandydatID",
                table: "Wiadomosci",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PracownikDziekanatuID",
                table: "Wiadomosci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wiadomosci",
                table: "Wiadomosci",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "PracownicyDziekanatu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Wydzial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracownicyDziekanatu", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "PracownicyDziekanatu",
                columns: new[] { "ID", "Imie", "Nazwisko", "Wydzial" },
                values: new object[] { 1, "Natalia", "Kowalczyk", 0 });

            migrationBuilder.InsertData(
                table: "PracownicyDziekanatu",
                columns: new[] { "ID", "Imie", "Nazwisko", "Wydzial" },
                values: new object[] { 2, "Jakub", "Nowak", 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Wiadomosci_PracownikDziekanatuID",
                table: "Wiadomosci",
                column: "PracownikDziekanatuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wiadomosci_Kandydaci_KandydatID",
                table: "Wiadomosci",
                column: "KandydatID",
                principalTable: "Kandydaci",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Wiadomosci_PracownicyDziekanatu_PracownikDziekanatuID",
                table: "Wiadomosci",
                column: "PracownikDziekanatuID",
                principalTable: "PracownicyDziekanatu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wiadomosci_Kandydaci_KandydatID",
                table: "Wiadomosci");

            migrationBuilder.DropForeignKey(
                name: "FK_Wiadomosci_PracownicyDziekanatu_PracownikDziekanatuID",
                table: "Wiadomosci");

            migrationBuilder.DropTable(
                name: "PracownicyDziekanatu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wiadomosci",
                table: "Wiadomosci");

            migrationBuilder.DropIndex(
                name: "IX_Wiadomosci_PracownikDziekanatuID",
                table: "Wiadomosci");

            migrationBuilder.DropColumn(
                name: "PracownikDziekanatuID",
                table: "Wiadomosci");

            migrationBuilder.RenameTable(
                name: "Wiadomosci",
                newName: "Wiadomosc");

            migrationBuilder.RenameIndex(
                name: "IX_Wiadomosci_KandydatID",
                table: "Wiadomosc",
                newName: "IX_Wiadomosc_KandydatID");

            migrationBuilder.AlterColumn<int>(
                name: "KandydatID",
                table: "Wiadomosc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wiadomosc",
                table: "Wiadomosc",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wiadomosc_Kandydaci_KandydatID",
                table: "Wiadomosc",
                column: "KandydatID",
                principalTable: "Kandydaci",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
