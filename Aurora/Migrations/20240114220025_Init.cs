﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aurora.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ulica = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NumerBudynku = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Miejscowosc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KierunkiStudiow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JezykWykladowy = table.Column<int>(type: "int", nullable: false),
                    Czesne = table.Column<double>(type: "float", nullable: false),
                    CzesneDlaObcokrajowcow = table.Column<double>(type: "float", nullable: false),
                    PoziomStudiow = table.Column<int>(type: "int", nullable: false),
                    MiejsceStudiow = table.Column<int>(type: "int", nullable: false),
                    NazwaKierunku = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FormaStudiow = table.Column<int>(type: "int", nullable: false),
                    Wydzial = table.Column<int>(type: "int", nullable: false),
                    OpisKierunku = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KierunkiStudiow", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wiadomosc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wiadomosc", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TuryRekrutacji",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KierunekStudiowID = table.Column<int>(type: "int", nullable: false),
                    DataOtwarcia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminZakonczeniaPrzyjmowaniaAplikacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LiczbaZajetychMiejsc = table.Column<int>(type: "int", nullable: false),
                    LimitPrzyjec = table.Column<int>(type: "int", nullable: false),
                    MinimalnyProgPunktowy = table.Column<double>(type: "float", nullable: false),
                    StatusTury = table.Column<int>(type: "int", nullable: false),
                    RodzajRekrutacji = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuryRekrutacji", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TuryRekrutacji_KierunkiStudiow_KierunekStudiowID",
                        column: x => x.KierunekStudiowID,
                        principalTable: "KierunkiStudiow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kandydaci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WiadomoscID = table.Column<int>(type: "int", nullable: false),
                    AdresID = table.Column<int>(type: "int", nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AdresEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kandydaci", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kandydaci_Adresy_AdresID",
                        column: x => x.AdresID,
                        principalTable: "Adresy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kandydaci_Wiadomosc_WiadomoscID",
                        column: x => x.WiadomoscID,
                        principalTable: "Wiadomosc",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KandydaciTuryRekrutacji",
                columns: table => new
                {
                    KandydatID = table.Column<int>(type: "int", nullable: false),
                    TuraRekrutacjiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KandydaciTuryRekrutacji", x => new { x.KandydatID, x.TuraRekrutacjiID });
                    table.ForeignKey(
                        name: "FK_KandydaciTuryRekrutacji_Kandydaci_KandydatID",
                        column: x => x.KandydatID,
                        principalTable: "Kandydaci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KandydaciTuryRekrutacji_TuryRekrutacji_TuraRekrutacjiID",
                        column: x => x.TuraRekrutacjiID,
                        principalTable: "TuryRekrutacji",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KandydatKierunekStudiow",
                columns: table => new
                {
                    KandydatID = table.Column<int>(type: "int", nullable: false),
                    KierunekStudiowID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KandydatKierunekStudiow", x => new { x.KandydatID, x.KierunekStudiowID });
                    table.ForeignKey(
                        name: "FK_KandydatKierunekStudiow_Kandydaci_KandydatID",
                        column: x => x.KandydatID,
                        principalTable: "Kandydaci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KandydatKierunekStudiow_KierunkiStudiow_KierunekStudiowID",
                        column: x => x.KierunekStudiowID,
                        principalTable: "KierunkiStudiow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KandydatUlubionyKierunekStudiow",
                columns: table => new
                {
                    KandydatID = table.Column<int>(type: "int", nullable: false),
                    UlubionyKierunekStudiowID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KandydatUlubionyKierunekStudiow", x => new { x.KandydatID, x.UlubionyKierunekStudiowID });
                    table.ForeignKey(
                        name: "FK_KandydatUlubionyKierunekStudiow_Kandydaci_KandydatID",
                        column: x => x.KandydatID,
                        principalTable: "Kandydaci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KandydatUlubionyKierunekStudiow_KierunkiStudiow_UlubionyKierunekStudiowID",
                        column: x => x.UlubionyKierunekStudiowID,
                        principalTable: "KierunkiStudiow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OplatyRekrutacyjne",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KandydatID = table.Column<int>(type: "int", nullable: false),
                    Kwota = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OplatyRekrutacyjne", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OplatyRekrutacyjne_Kandydaci_KandydatID",
                        column: x => x.KandydatID,
                        principalTable: "Kandydaci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AplikacjeRekrutacyjne",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuraRekrutacjiID = table.Column<int>(type: "int", nullable: false),
                    OplataRekrutacyjnaID = table.Column<int>(type: "int", nullable: false),
                    DataZlozenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    WspolczynnikRekrutacyjnyID = table.Column<int>(type: "int", nullable: false),
                    KandydatID = table.Column<int>(type: "int", nullable: false),
                    KierunekStudiowID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikacjeRekrutacyjne", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AplikacjeRekrutacyjne_Kandydaci_KandydatID",
                        column: x => x.KandydatID,
                        principalTable: "Kandydaci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AplikacjeRekrutacyjne_KierunkiStudiow_KierunekStudiowID",
                        column: x => x.KierunekStudiowID,
                        principalTable: "KierunkiStudiow",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AplikacjeRekrutacyjne_OplatyRekrutacyjne_OplataRekrutacyjnaID",
                        column: x => x.OplataRekrutacyjnaID,
                        principalTable: "OplatyRekrutacyjne",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AplikacjeRekrutacyjne_TuryRekrutacji_TuraRekrutacjiID",
                        column: x => x.TuraRekrutacjiID,
                        principalTable: "TuryRekrutacji",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WspolczynnikiRekrutacyjne",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AplikacjaRekrutacyjnaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WspolczynnikiRekrutacyjne", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WspolczynnikiRekrutacyjne_AplikacjeRekrutacyjne_AplikacjaRekrutacyjnaID",
                        column: x => x.AplikacjaRekrutacyjnaID,
                        principalTable: "AplikacjeRekrutacyjne",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkladoweWspRekrut",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WspolczynnikRekrutacyjnyID = table.Column<int>(type: "int", nullable: false),
                    WspolczynnikRekrutacyjnyID1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PrzedmiotMaturalny = table.Column<int>(type: "int", nullable: true),
                    RodzajSkladowejWspRekrut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkladoweWspRekrut", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkladoweWspRekrut_WspolczynnikiRekrutacyjne_WspolczynnikRekrutacyjnyID1",
                        column: x => x.WspolczynnikRekrutacyjnyID1,
                        principalTable: "WspolczynnikiRekrutacyjne",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Egzaminy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuraRekrutacjiID = table.Column<int>(type: "int", nullable: true),
                    KandydatID = table.Column<int>(type: "int", nullable: false),
                    Organ = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ocena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LiczbaPunktow = table.Column<double>(type: "float", nullable: true),
                    MaksymalnaLiczbaPunktow = table.Column<double>(type: "float", nullable: true),
                    WynikProcentowy = table.Column<double>(type: "float", nullable: true),
                    SkladowaWspRekrutID = table.Column<int>(type: "int", nullable: false),
                    Dziedzina = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Przedmiot = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Forma = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Poziom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ZawodNauczany = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Kod = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Kwalifikacje = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egzaminy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Egzaminy_Kandydaci_KandydatID",
                        column: x => x.KandydatID,
                        principalTable: "Kandydaci",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Egzaminy_SkladoweWspRekrut_SkladowaWspRekrutID",
                        column: x => x.SkladowaWspRekrutID,
                        principalTable: "SkladoweWspRekrut",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Egzaminy_TuryRekrutacji_TuraRekrutacjiID",
                        column: x => x.TuraRekrutacjiID,
                        principalTable: "TuryRekrutacji",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplikacjeRekrutacyjne_KandydatID",
                table: "AplikacjeRekrutacyjne",
                column: "KandydatID");

            migrationBuilder.CreateIndex(
                name: "IX_AplikacjeRekrutacyjne_KierunekStudiowID",
                table: "AplikacjeRekrutacyjne",
                column: "KierunekStudiowID");

            migrationBuilder.CreateIndex(
                name: "IX_AplikacjeRekrutacyjne_OplataRekrutacyjnaID",
                table: "AplikacjeRekrutacyjne",
                column: "OplataRekrutacyjnaID");

            migrationBuilder.CreateIndex(
                name: "IX_AplikacjeRekrutacyjne_TuraRekrutacjiID",
                table: "AplikacjeRekrutacyjne",
                column: "TuraRekrutacjiID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Egzaminy_KandydatID",
                table: "Egzaminy",
                column: "KandydatID");

            migrationBuilder.CreateIndex(
                name: "IX_Egzaminy_SkladowaWspRekrutID",
                table: "Egzaminy",
                column: "SkladowaWspRekrutID");

            migrationBuilder.CreateIndex(
                name: "IX_Egzaminy_TuraRekrutacjiID",
                table: "Egzaminy",
                column: "TuraRekrutacjiID");

            migrationBuilder.CreateIndex(
                name: "IX_Kandydaci_AdresID",
                table: "Kandydaci",
                column: "AdresID");

            migrationBuilder.CreateIndex(
                name: "IX_Kandydaci_PESEL",
                table: "Kandydaci",
                column: "PESEL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kandydaci_WiadomoscID",
                table: "Kandydaci",
                column: "WiadomoscID");

            migrationBuilder.CreateIndex(
                name: "IX_KandydaciTuryRekrutacji_TuraRekrutacjiID",
                table: "KandydaciTuryRekrutacji",
                column: "TuraRekrutacjiID");

            migrationBuilder.CreateIndex(
                name: "IX_KandydatKierunekStudiow_KierunekStudiowID",
                table: "KandydatKierunekStudiow",
                column: "KierunekStudiowID");

            migrationBuilder.CreateIndex(
                name: "IX_KandydatUlubionyKierunekStudiow_UlubionyKierunekStudiowID",
                table: "KandydatUlubionyKierunekStudiow",
                column: "UlubionyKierunekStudiowID");

            migrationBuilder.CreateIndex(
                name: "IX_OplatyRekrutacyjne_KandydatID",
                table: "OplatyRekrutacyjne",
                column: "KandydatID");

            migrationBuilder.CreateIndex(
                name: "IX_SkladoweWspRekrut_WspolczynnikRekrutacyjnyID1",
                table: "SkladoweWspRekrut",
                column: "WspolczynnikRekrutacyjnyID1");

            migrationBuilder.CreateIndex(
                name: "IX_TuryRekrutacji_KierunekStudiowID",
                table: "TuryRekrutacji",
                column: "KierunekStudiowID");

            migrationBuilder.CreateIndex(
                name: "IX_WspolczynnikiRekrutacyjne_AplikacjaRekrutacyjnaID",
                table: "WspolczynnikiRekrutacyjne",
                column: "AplikacjaRekrutacyjnaID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Egzaminy");

            migrationBuilder.DropTable(
                name: "KandydaciTuryRekrutacji");

            migrationBuilder.DropTable(
                name: "KandydatKierunekStudiow");

            migrationBuilder.DropTable(
                name: "KandydatUlubionyKierunekStudiow");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SkladoweWspRekrut");

            migrationBuilder.DropTable(
                name: "WspolczynnikiRekrutacyjne");

            migrationBuilder.DropTable(
                name: "AplikacjeRekrutacyjne");

            migrationBuilder.DropTable(
                name: "OplatyRekrutacyjne");

            migrationBuilder.DropTable(
                name: "TuryRekrutacji");

            migrationBuilder.DropTable(
                name: "Kandydaci");

            migrationBuilder.DropTable(
                name: "KierunkiStudiow");

            migrationBuilder.DropTable(
                name: "Adresy");

            migrationBuilder.DropTable(
                name: "Wiadomosc");
        }
    }
}
