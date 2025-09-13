using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class Onarkafotopathcolumnsaddbookstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ARKAKAPAKFOTOPATH",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ONKAPAKFOTOPATH",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ARKAKAPAKFOTOPATH",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ONKAPAKFOTOPATH",
                table: "Books");
        }
    }
}
