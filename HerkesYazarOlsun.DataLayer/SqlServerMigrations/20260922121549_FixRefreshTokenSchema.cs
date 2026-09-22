using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class FixRefreshTokenSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "YayinAyarlari",
                newName: "YayinAyarlari",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "WriterStars",
                newName: "WriterStars",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "WriterFollow",
                newName: "WriterFollow",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UsersDetails",
                newName: "UsersDetails",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Talepler",
                newName: "Talepler",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Sponsorlar",
                newName: "Sponsorlar",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                newName: "RefreshTokens",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Profil",
                newName: "Profil",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "OdemeSponsorlari",
                newName: "OdemeSponsorlari",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Odeme",
                newName: "Odeme",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Kartlar",
                newName: "Kartlar",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FavoriYazarlar",
                newName: "FavoriYazarlar",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Favoriler",
                newName: "Favoriler",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "FavoriBooks",
                newName: "FavoriBooks",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CategoryYayinAyarlari",
                newName: "CategoryYayinAyarlari",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Category",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CarouselDuyuru",
                newName: "CarouselDuyuru",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BooksStars",
                newName: "BooksStars",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BooksPages",
                newName: "BooksPages",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BooksDegerlendirme",
                newName: "BooksDegerlendirme",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "BooksComment",
                newName: "BooksComment",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Books",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Bildirimler",
                newName: "Bildirimler",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Ayarlar",
                newName: "Ayarlar",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AccountLogin",
                newName: "AccountLogin",
                newSchema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "YayinAyarlari",
                schema: "dbo",
                newName: "YayinAyarlari");

            migrationBuilder.RenameTable(
                name: "WriterStars",
                schema: "dbo",
                newName: "WriterStars");

            migrationBuilder.RenameTable(
                name: "WriterFollow",
                schema: "dbo",
                newName: "WriterFollow");

            migrationBuilder.RenameTable(
                name: "UsersDetails",
                schema: "dbo",
                newName: "UsersDetails");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Talepler",
                schema: "dbo",
                newName: "Talepler");

            migrationBuilder.RenameTable(
                name: "Sponsorlar",
                schema: "dbo",
                newName: "Sponsorlar");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                schema: "dbo",
                newName: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "Profil",
                schema: "dbo",
                newName: "Profil");

            migrationBuilder.RenameTable(
                name: "OdemeSponsorlari",
                schema: "dbo",
                newName: "OdemeSponsorlari");

            migrationBuilder.RenameTable(
                name: "Odeme",
                schema: "dbo",
                newName: "Odeme");

            migrationBuilder.RenameTable(
                name: "Kartlar",
                schema: "dbo",
                newName: "Kartlar");

            migrationBuilder.RenameTable(
                name: "FavoriYazarlar",
                schema: "dbo",
                newName: "FavoriYazarlar");

            migrationBuilder.RenameTable(
                name: "Favoriler",
                schema: "dbo",
                newName: "Favoriler");

            migrationBuilder.RenameTable(
                name: "FavoriBooks",
                schema: "dbo",
                newName: "FavoriBooks");

            migrationBuilder.RenameTable(
                name: "CategoryYayinAyarlari",
                schema: "dbo",
                newName: "CategoryYayinAyarlari");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "dbo",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "CarouselDuyuru",
                schema: "dbo",
                newName: "CarouselDuyuru");

            migrationBuilder.RenameTable(
                name: "BooksStars",
                schema: "dbo",
                newName: "BooksStars");

            migrationBuilder.RenameTable(
                name: "BooksPages",
                schema: "dbo",
                newName: "BooksPages");

            migrationBuilder.RenameTable(
                name: "BooksDegerlendirme",
                schema: "dbo",
                newName: "BooksDegerlendirme");

            migrationBuilder.RenameTable(
                name: "BooksComment",
                schema: "dbo",
                newName: "BooksComment");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "dbo",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "Bildirimler",
                schema: "dbo",
                newName: "Bildirimler");

            migrationBuilder.RenameTable(
                name: "Ayarlar",
                schema: "dbo",
                newName: "Ayarlar");

            migrationBuilder.RenameTable(
                name: "AccountLogin",
                schema: "dbo",
                newName: "AccountLogin");
        }
    }
}
