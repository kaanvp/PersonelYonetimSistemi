using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonelYonetimSistemiNew.Migrations
{
    /// <inheritdoc />
    public partial class AddFileUploadFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContractFilePath",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CvFilePath",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractFilePath",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "CvFilePath",
                table: "Personeller");
        }
    }
}
