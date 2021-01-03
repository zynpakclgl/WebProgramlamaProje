using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProje.Data.Migrations
{
    public partial class Tablolar2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araba_Ilan_IlanId",
                table: "Araba");

            migrationBuilder.AddColumn<int>(
                name: "IlanNo",
                table: "Ilan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IlanId",
                table: "Araba",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IlanNo",
                table: "Araba",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Araba_Ilan_IlanId",
                table: "Araba",
                column: "IlanId",
                principalTable: "Ilan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Araba_Ilan_IlanId",
                table: "Araba");

            migrationBuilder.DropColumn(
                name: "IlanNo",
                table: "Ilan");

            migrationBuilder.DropColumn(
                name: "IlanNo",
                table: "Araba");

            migrationBuilder.AlterColumn<int>(
                name: "IlanId",
                table: "Araba",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Araba_Ilan_IlanId",
                table: "Araba",
                column: "IlanId",
                principalTable: "Ilan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
