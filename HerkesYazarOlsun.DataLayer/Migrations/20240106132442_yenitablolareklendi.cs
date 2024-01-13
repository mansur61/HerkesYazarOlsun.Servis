using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class yenitablolareklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bildirimler",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsTakip = table.Column<bool>(type: "boolean", nullable: false),
                    IsKitapYayin = table.Column<bool>(type: "boolean", nullable: false),
                    IsKitapYorum = table.Column<bool>(type: "boolean", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bildirimler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profil",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MimeType = table.Column<string>(type: "text", nullable: true),
                    ProfilResimURl = table.Column<string>(type: "text", nullable: true),
                    ProfilResimBase64 = table.Column<string>(type: "text", nullable: true),
                    ProfilResimName = table.Column<string>(type: "text", nullable: true),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: true),
                    ProfilArkaplanResmi = table.Column<string>(type: "text", nullable: true),
                    CREATE_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profil", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsersDetails",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HAKKINDA = table.Column<string>(type: "text", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TEL = table.Column<long>(type: "bigint", nullable: true),
                    WebSite = table.Column<string>(type: "text", nullable: true),
                    TwitterLink = table.Column<string>(type: "text", nullable: true),
                    FacebookLink = table.Column<string>(type: "text", nullable: true),
                    LinkedinLink = table.Column<string>(type: "text", nullable: true),
                    InstagramLink = table.Column<string>(type: "text", nullable: true),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: true),
                    CREATE_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ayarlar",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    isDegisiklik = table.Column<int>(type: "integer", nullable: true),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: false),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayarlar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ayarlar_Profil_ID",
                        column: x => x.ID,
                        principalTable: "Profil",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ayarlar_UsersDetails_ID",
                        column: x => x.ID,
                        principalTable: "UsersDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ayarlar");

            migrationBuilder.DropTable(
                name: "Bildirimler");

            migrationBuilder.DropTable(
                name: "Profil");

            migrationBuilder.DropTable(
                name: "UsersDetails");
        }
    }
}
