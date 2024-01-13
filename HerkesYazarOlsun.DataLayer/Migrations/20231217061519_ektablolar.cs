using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ektablolar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksStars",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StarPuani = table.Column<int>(type: "integer", nullable: false),
                    LoginUserId = table.Column<int>(type: "integer", nullable: false),
                    BookaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksStars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FavoriBooks",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BOOKS_ID = table.Column<long>(type: "bigint", nullable: false),
                    USER_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriBooks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WriterFollow",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoginUserId = table.Column<int>(type: "integer", nullable: false),
                    YazarId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriterFollow", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WriterStars",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StarPuani = table.Column<int>(type: "integer", nullable: false),
                    LoginUserId = table.Column<int>(type: "integer", nullable: false),
                    YazarId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriterStars", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksStars");

            migrationBuilder.DropTable(
                name: "FavoriBooks");

            migrationBuilder.DropTable(
                name: "WriterFollow");

            migrationBuilder.DropTable(
                name: "WriterStars");
        }
    }
}
