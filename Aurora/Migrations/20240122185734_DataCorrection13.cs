using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrection13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DziedzinaEgzaminuWstepnego",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dziedzina = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DziedzinaEgzaminuWstepnego", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DziedzinaEgzaminuWstepnego_Dziedzina",
                table: "DziedzinaEgzaminuWstepnego",
                column: "Dziedzina",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DziedzinaEgzaminuWstepnego");
        }
    }
}
