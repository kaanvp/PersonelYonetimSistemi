using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonelYonetimSistemiNew.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKullaniciHareketleriTableWithNewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SalaryRange",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RequiredSkills",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JobDescription",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Durum",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAdresi",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "KullaniciHareketleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciHareketleri_PersonelId",
                table: "KullaniciHareketleri",
                column: "PersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciHareketleri_Personeller_PersonelId",
                table: "KullaniciHareketleri",
                column: "PersonelId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciHareketleri_Personeller_PersonelId",
                table: "KullaniciHareketleri");

            migrationBuilder.DropIndex(
                name: "IX_KullaniciHareketleri_PersonelId",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "IpAdresi",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "KullaniciHareketleri");

            migrationBuilder.AlterColumn<string>(
                name: "SalaryRange",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequiredSkills",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobDescription",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
