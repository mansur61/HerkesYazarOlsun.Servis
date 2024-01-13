using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class newbaseenttityaypilarineeklemeyapildi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "UsersDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "Profil",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "OdemeSponsorlari",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "Odeme",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "Kartlar",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "FavoriBooks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "FAVORILER",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "FAVORI_YAZARLAR",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "BooksPages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "BooksComment",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "Bildirimler",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "Ayarlar",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "Profil");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "OdemeSponsorlari");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "Odeme");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "Kartlar");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "FavoriBooks");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "FAVORILER");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "FAVORI_YAZARLAR");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "BooksPages");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "BooksComment");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "Bildirimler");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "Ayarlar");
        }
    }
}
