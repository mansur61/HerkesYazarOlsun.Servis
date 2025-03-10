using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddYayinAyarlariDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YayinAyarlari",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToplamYildiz = table.Column<int>(type: "integer", nullable: false),
                    ToplamBegeni = table.Column<int>(type: "integer", nullable: false),
                    ToplamYorum = table.Column<int>(type: "integer", nullable: false),
                    ToplamDegerlendirme = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinAyarlari", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YayinAyarlari");
        }
    }
}
