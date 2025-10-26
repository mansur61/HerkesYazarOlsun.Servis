using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class cateyayinayartableadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryYayinAyarlari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToplamYildiz = table.Column<int>(type: "int", nullable: true),
                    ToplamBegeni = table.Column<int>(type: "int", nullable: true),
                    ToplamYorum = table.Column<int>(type: "int", nullable: true),
                    ToplamDegerlendirme = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryYayinAyarlari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoryYayinAyarlari_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryYayinAyarlari_CategoryId",
                table: "CategoryYayinAyarlari",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryYayinAyarlari");
        }
    }
}
