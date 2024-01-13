using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class yenialanlareklendiilgilitablolara : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "OdemeSponsorlari",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mesaj",
                table: "OdemeSponsorlari",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameSurname",
                table: "OdemeSponsorlari",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Tel",
                table: "OdemeSponsorlari",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Tutar",
                table: "Kartlar",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "OdemeSponsorlari");

            migrationBuilder.DropColumn(
                name: "Mesaj",
                table: "OdemeSponsorlari");

            migrationBuilder.DropColumn(
                name: "NameSurname",
                table: "OdemeSponsorlari");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "OdemeSponsorlari");

            migrationBuilder.DropColumn(
                name: "Tutar",
                table: "Kartlar");
        }
    }
}
