using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    public partial class RemoveBooksIDFromBooksPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // BooksID FK siliniyor
            migrationBuilder.DropForeignKey(
                name: "FK_BooksPages_Books_BooksID",
                table: "BooksPages");

            // BooksID index siliniyor
            migrationBuilder.DropIndex(
                name: "IX_BooksPages_BooksID",
                table: "BooksPages");

            // BooksID kolonu siliniyor
            migrationBuilder.DropColumn(
                name: "BooksID",
                table: "BooksPages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Geri dönüş: BooksID kolonu ve FK ekleniyor
            migrationBuilder.AddColumn<long>(
                name: "BooksID",
                table: "BooksPages",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksPages_BooksID",
                table: "BooksPages",
                column: "BooksID");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksPages_Books_BooksID",
                table: "BooksPages",
                column: "BooksID",
                principalTable: "Books",
                principalColumn: "ID");
        }
    }
}
