using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonelYonetimSistemiNew.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIzınlerFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Izinler");

            migrationBuilder.DropColumn(
                name: "Pozisyon",
                table: "Izinler");

            migrationBuilder.AlterColumn<string>(
                name: "TCKN",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaritalStatus",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CvFilePath",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContractFilePath",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PermitFile",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "Izinler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PozisyonId",
                table: "Izinler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_PersonelId",
                table: "Izinler",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_PozisyonId",
                table: "Izinler",
                column: "PozisyonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Izinler_Personeller_PersonelId",
                table: "Izinler",
                column: "PersonelId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Izinler_Pozisyonlar_PozisyonId",
                table: "Izinler",
                column: "PozisyonId",
                principalTable: "Pozisyonlar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izinler_Personeller_PersonelId",
                table: "Izinler");

            migrationBuilder.DropForeignKey(
                name: "FK_Izinler_Pozisyonlar_PozisyonId",
                table: "Izinler");

            migrationBuilder.DropIndex(
                name: "IX_Izinler_PersonelId",
                table: "Izinler");

            migrationBuilder.DropIndex(
                name: "IX_Izinler_PozisyonId",
                table: "Izinler");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "Izinler");

            migrationBuilder.DropColumn(
                name: "PozisyonId",
                table: "Izinler");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Izinler");

            migrationBuilder.AlterColumn<string>(
                name: "TCKN",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaritalStatus",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CvFilePath",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContractFilePath",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PermitFile",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Izinler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Pozisyon",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
