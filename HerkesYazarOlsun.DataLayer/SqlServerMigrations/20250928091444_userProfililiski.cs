using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class userProfililiski : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Profil_LoginUserId",
                table: "Profil",
                column: "LoginUserId",
                unique: true,
                filter: "[LoginUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Profil_Users_LoginUserId",
                table: "Profil",
                column: "LoginUserId",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profil_Users_LoginUserId",
                table: "Profil");

            migrationBuilder.DropIndex(
                name: "IX_Profil_LoginUserId",
                table: "Profil");
        }
    }
}
