using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonelYonetimSistemiNew.Migrations
{
    /// <inheritdoc />
    public partial class FinalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciHareketleri_Departmant_DepartmanId",
                table: "KullaniciHareketleri");

            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciHareketleri_Pozisyonlar_PozisyonId",
                table: "KullaniciHareketleri");

            migrationBuilder.DropIndex(
                name: "IX_KullaniciHareketleri_DepartmanId",
                table: "KullaniciHareketleri");

            migrationBuilder.DropIndex(
                name: "IX_KullaniciHareketleri_PozisyonId",
                table: "KullaniciHareketleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departmant",
                table: "Departmant");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Pozisyonlar");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "City",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "DateofBirth",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "DepartmanId",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "EmpNum",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "MidName",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "PozisyonId",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "KullaniciHareketleri");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "Departmant");

            migrationBuilder.RenameTable(
                name: "Departmant",
                newName: "Departmanlar");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departmanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departmanlar",
                table: "Departmanlar",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmanId = table.Column<int>(type: "int", nullable: true),
                    PozisyonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personeller_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Personeller_Pozisyonlar_PozisyonId",
                        column: x => x.PozisyonId,
                        principalTable: "Pozisyonlar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_DepartmanId",
                table: "Personeller",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_PozisyonId",
                table: "Personeller",
                column: "PozisyonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departmanlar",
                table: "Departmanlar");

            migrationBuilder.RenameTable(
                name: "Departmanlar",
                newName: "Departmant");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Pozisyonlar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "KullaniciHareketleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateofBirth",
                table: "KullaniciHareketleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmanId",
                table: "KullaniciHareketleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "KullaniciHareketleri",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpNum",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "KullaniciHareketleri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MidName",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "KullaniciHareketleri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "KullaniciHareketleri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PozisyonId",
                table: "KullaniciHareketleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "KullaniciHareketleri",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departmant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "Departmant",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departmant",
                table: "Departmant",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciHareketleri_DepartmanId",
                table: "KullaniciHareketleri",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciHareketleri_PozisyonId",
                table: "KullaniciHareketleri",
                column: "PozisyonId");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciHareketleri_Departmant_DepartmanId",
                table: "KullaniciHareketleri",
                column: "DepartmanId",
                principalTable: "Departmant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciHareketleri_Pozisyonlar_PozisyonId",
                table: "KullaniciHareketleri",
                column: "PozisyonId",
                principalTable: "Pozisyonlar",
                principalColumn: "Id");
        }
    }
}
