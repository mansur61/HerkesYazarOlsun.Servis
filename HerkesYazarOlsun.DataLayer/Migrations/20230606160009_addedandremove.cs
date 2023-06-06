using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedandremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KITAPADI",
                table: "KITAPSAYFALARI");

            migrationBuilder.AddColumn<string>(
                name: "ARKAKAPAKYAZISI",
                table: "KITAP",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ARKAKAPAKYAZISI",
                table: "KITAP");

            migrationBuilder.AddColumn<string>(
                name: "KITAPADI",
                table: "KITAPSAYFALARI",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
