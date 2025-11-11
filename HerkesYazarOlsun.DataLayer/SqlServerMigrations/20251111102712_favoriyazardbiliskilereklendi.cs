using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class favoriyazardbiliskilereklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "YazarId",
                table: "FavoriYazarlar",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "LoginUserId",
                table: "FavoriYazarlar",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriYazarlar_LoginUserId",
                table: "FavoriYazarlar",
                column: "LoginUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriYazarlar_YazarId",
                table: "FavoriYazarlar",
                column: "YazarId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriYazarlar_Users_LoginUserId",
                table: "FavoriYazarlar",
                column: "LoginUserId",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriYazarlar_Users_YazarId",
                table: "FavoriYazarlar",
                column: "YazarId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriYazarlar_Users_LoginUserId",
                table: "FavoriYazarlar");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriYazarlar_Users_YazarId",
                table: "FavoriYazarlar");

            migrationBuilder.DropIndex(
                name: "IX_FavoriYazarlar_LoginUserId",
                table: "FavoriYazarlar");

            migrationBuilder.DropIndex(
                name: "IX_FavoriYazarlar_YazarId",
                table: "FavoriYazarlar");

            migrationBuilder.AlterColumn<int>(
                name: "YazarId",
                table: "FavoriYazarlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LoginUserId",
                table: "FavoriYazarlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
