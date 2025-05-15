using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonelYonetimSistemiNew.Migrations
{
    /// <inheritdoc />
    public partial class AddPozisyonAndPersonelFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Pozisyonlar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JobDescription",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequiredSkills",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SalaryRange",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TCKN",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Pozisyonlar");

            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "Pozisyonlar");

            migrationBuilder.DropColumn(
                name: "RequiredSkills",
                table: "Pozisyonlar");

            migrationBuilder.DropColumn(
                name: "SalaryRange",
                table: "Pozisyonlar");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "TCKN",
                table: "Personeller");
        }
    }
}
