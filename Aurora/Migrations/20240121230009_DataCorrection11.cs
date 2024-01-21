using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class DataCorrection11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OpisKierunku",
                table: "KierunkiStudiow",
                type: "nvarchar(1023)",
                maxLength: 1023,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1023)",
                oldMaxLength: 1023);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OpisKierunku",
                table: "KierunkiStudiow",
                type: "nvarchar(1023)",
                maxLength: 1023,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1023)",
                oldMaxLength: 1023,
                oldNullable: true);
        }
    }
}
