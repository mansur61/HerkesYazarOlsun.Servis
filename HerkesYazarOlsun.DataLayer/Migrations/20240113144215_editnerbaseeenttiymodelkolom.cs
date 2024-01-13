using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class editnerbaseeenttiymodelkolom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "UsersDetails",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Users",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Profil",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "OdemeSponsorlari",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Odeme",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Kartlar",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "FavoriBooks",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "FAVORILER",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "FAVORI_YAZARLAR",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "BooksPages",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "BooksComment",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Books",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Bildirimler",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "Ayarlar",
                newName: "OLUSTURAN_EMAIL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAİL",
                table: "AccountLogin",
                newName: "OLUSTURAN_EMAIL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "UsersDetails",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "Users",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "Profil",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "OdemeSponsorlari",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "Odeme",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "Kartlar",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "FavoriBooks",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "FAVORILER",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "FAVORI_YAZARLAR",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "BooksPages",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "BooksComment",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "Books",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "Bildirimler",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "Ayarlar",
                newName: "OLUSTURAN_EMAİL");

            migrationBuilder.RenameColumn(
                name: "OLUSTURAN_EMAIL",
                table: "AccountLogin",
                newName: "OLUSTURAN_EMAİL");
        }
    }
}
