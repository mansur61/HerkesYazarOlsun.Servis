using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class FixBooksPagesBookId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eski BooksID kolonu DB'de yoksa ekle (nullable bırakıyoruz)
            migrationBuilder.AddColumn<long>(
                name: "BooksID",
                table: "BooksPages",
                type: "bigint",
                nullable: true
            );

            // NOT: FK veya index ekleme yok, ilişkiler BookId üzerinden zaten tanımlı
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BooksID",
                table: "BooksPages"
            );
        }

    }
}
