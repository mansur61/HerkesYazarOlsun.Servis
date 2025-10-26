using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class categortconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryYayinAyarlari_CategoryId",
                table: "CategoryYayinAyarlari");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryYayinAyarlari_CategoryId",
                table: "CategoryYayinAyarlari",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryYayinAyarlari_CategoryId",
                table: "CategoryYayinAyarlari");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryYayinAyarlari_CategoryId",
                table: "CategoryYayinAyarlari",
                column: "CategoryId");
        }
    }
}
