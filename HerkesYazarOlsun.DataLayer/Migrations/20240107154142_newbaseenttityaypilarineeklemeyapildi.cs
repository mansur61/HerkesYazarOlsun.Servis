using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class newbaseenttityaypilarineeklemeyapildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "UsersDetails",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "Profil",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "OdemeSponsorlari",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "Odeme",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "Kartlar",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "FavoriBooks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "FAVORILER",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "FAVORI_YAZARLAR",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "BooksPages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "BooksComment",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "Books",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "Bildirimler",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAİL",
                table: "Ayarlar",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "UsersDetails");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Profil");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "OdemeSponsorlari");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Odeme");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Kartlar");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "FavoriBooks");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "FAVORILER");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "FAVORI_YAZARLAR");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "BooksPages");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "BooksComment");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Bildirimler");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Ayarlar");
        }
    }
}
