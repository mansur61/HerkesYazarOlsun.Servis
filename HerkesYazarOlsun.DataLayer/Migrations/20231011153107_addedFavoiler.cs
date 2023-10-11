using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedFavoiler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KISILER");

            migrationBuilder.DropTable(
                name: "KITAP");

            migrationBuilder.DropTable(
                name: "KITAPSAYFALARI");

            migrationBuilder.DropTable(
                name: "TEST");

            migrationBuilder.CreateTable(
                name: "FAVORILER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BOOKS_ID = table.Column<string>(type: "text", nullable: false),
                    USER_ID = table.Column<string>(type: "text", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAVORILER", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAVORILER");

            migrationBuilder.CreateTable(
                name: "KISILER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AD = table.Column<string>(type: "text", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: false),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SOYAD = table.Column<string>(type: "text", nullable: false),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: false),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KISILER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KITAP",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ARKAKAPAKFOTO = table.Column<string>(type: "text", nullable: false),
                    ARKAKAPAKYAZISI = table.Column<string>(type: "text", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: false),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: false),
                    KITAPADI = table.Column<string>(type: "text", nullable: false),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ONKAPAKFOTO = table.Column<string>(type: "text", nullable: false),
                    ONSOZ = table.Column<string>(type: "text", nullable: false),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: false),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KITAP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KITAPSAYFALARI",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CREATE_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: false),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: false),
                    KITAP_ID = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SAYFAKAPAKFOTO = table.Column<string>(type: "text", nullable: false),
                    SAYFAYAZISI = table.Column<string>(type: "text", nullable: false),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: false),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KITAPSAYFALARI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TEST",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AD = table.Column<string>(type: "text", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: false),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: false),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEST", x => x.ID);
                });
        }
    }
}
