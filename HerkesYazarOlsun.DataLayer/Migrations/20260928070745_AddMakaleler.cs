using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddMakaleler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Makaleler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    YazarId = table.Column<long>(type: "bigint", nullable: false),
                    Yazar = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Baslik = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Metin = table.Column<string>(type: "text", nullable: false),
                    Uzanti = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    OlusturmaTarihi = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    YayinTarihi = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makaleler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Makaleler_Users_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MakaleBelgeler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Icerik = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakaleBelgeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MakaleBelgeler_Makaleler_Id",
                        column: x => x.Id,
                        principalTable: "Makaleler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Makaleler_YayinTarihi_Id",
                table: "Makaleler",
                columns: new[] { "YayinTarihi", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Makaleler_YazarId_YayinTarihi_Id",
                table: "Makaleler",
                columns: new[] { "YazarId", "YayinTarihi", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MakaleBelgeler",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Makaleler",
                schema: "dbo");
        }
    }
}
