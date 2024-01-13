using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ayarlartablosundaduzenlemeleryapildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ayarlar_Profil_ID",
                table: "Ayarlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Ayarlar_UsersDetails_ID",
                table: "Ayarlar");

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                table: "Ayarlar",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "BildirimID",
                table: "Ayarlar",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProfileID",
                table: "Ayarlar",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserDetailID",
                table: "Ayarlar",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BildirimID",
                table: "Ayarlar");

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Ayarlar");

            migrationBuilder.DropColumn(
                name: "UserDetailID",
                table: "Ayarlar");

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                table: "Ayarlar",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Ayarlar_Profil_ID",
                table: "Ayarlar",
                column: "ID",
                principalTable: "Profil",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ayarlar_UsersDetails_ID",
                table: "Ayarlar",
                column: "ID",
                principalTable: "UsersDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
