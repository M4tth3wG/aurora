using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class AddingDataAdrian4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TuryRekrutacji",
                columns: new[] { "ID", "DataOtwarcia", "DataZakonczenia", "KierunekStudiowID", "LiczbaZajetychMiejsc", "LimitPrzyjec", "MinimalnyProgPunktowy", "RodzajRekrutacji", "StatusTury", "TerminZakonczeniaPrzyjmowaniaAplikacji" },
                values: new object[] { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, 100, 0.0, 2, 2, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TuryRekrutacji",
                keyColumn: "ID",
                keyValue: 7);
        }
    }
}
