using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProje.Data.Migrations
{
    public partial class Tablolar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresAd = table.Column<string>(nullable: true),
                    Ulke = table.Column<string>(nullable: true),
                    Il = table.Column<string>(nullable: true),
                    Ilce = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArabaModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabaModelAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArabaModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cekis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CekisAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cekis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ilan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlanTarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KasaTipi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KasaTipiAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KasaTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Renk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RenkAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Satici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    AdresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Satici_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Araba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlanId = table.Column<int>(nullable: false),
                    MarkaId = table.Column<int>(nullable: false),
                    ArabaModelId = table.Column<int>(nullable: false),
                    Yil = table.Column<int>(nullable: false),
                    Yakit = table.Column<string>(nullable: true),
                    Vites = table.Column<string>(nullable: true),
                    MotorGücü = table.Column<int>(nullable: false),
                    MotorHacmi = table.Column<int>(nullable: false),
                    Km = table.Column<double>(nullable: false),
                    RenkId = table.Column<int>(nullable: false),
                    KasaTipiId = table.Column<int>(nullable: false),
                    CekisId = table.Column<int>(nullable: false),
                    Plaka = table.Column<string>(nullable: true),
                    Durumu = table.Column<string>(nullable: true),
                    Fiyat = table.Column<double>(nullable: false),
                    Fotograf = table.Column<string>(nullable: true),
                    SaticiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Araba_ArabaModel_ArabaModelId",
                        column: x => x.ArabaModelId,
                        principalTable: "ArabaModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Araba_Cekis_CekisId",
                        column: x => x.CekisId,
                        principalTable: "Cekis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Araba_Ilan_IlanId",
                        column: x => x.IlanId,
                        principalTable: "Ilan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Araba_KasaTipi_KasaTipiId",
                        column: x => x.KasaTipiId,
                        principalTable: "KasaTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Araba_Marka_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Marka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Araba_Renk_RenkId",
                        column: x => x.RenkId,
                        principalTable: "Renk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Araba_Satici_SaticiId",
                        column: x => x.SaticiId,
                        principalTable: "Satici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Araba_ArabaModelId",
                table: "Araba",
                column: "ArabaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Araba_CekisId",
                table: "Araba",
                column: "CekisId");

            migrationBuilder.CreateIndex(
                name: "IX_Araba_IlanId",
                table: "Araba",
                column: "IlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Araba_KasaTipiId",
                table: "Araba",
                column: "KasaTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_Araba_MarkaId",
                table: "Araba",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Araba_RenkId",
                table: "Araba",
                column: "RenkId");

            migrationBuilder.CreateIndex(
                name: "IX_Araba_SaticiId",
                table: "Araba",
                column: "SaticiId");

            migrationBuilder.CreateIndex(
                name: "IX_Satici_AdresId",
                table: "Satici",
                column: "AdresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Araba");

            migrationBuilder.DropTable(
                name: "ArabaModel");

            migrationBuilder.DropTable(
                name: "Cekis");

            migrationBuilder.DropTable(
                name: "Ilan");

            migrationBuilder.DropTable(
                name: "KasaTipi");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropTable(
                name: "Renk");

            migrationBuilder.DropTable(
                name: "Satici");

            migrationBuilder.DropTable(
                name: "Adres");
        }
    }
}
