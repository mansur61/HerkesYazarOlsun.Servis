using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class bookstartiliskiller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "LoginUserId",
                table: "BooksStars",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BooksStars_LoginUserId",
                table: "BooksStars",
                column: "LoginUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksStars_Users_LoginUserId",
                table: "BooksStars",
                column: "LoginUserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksStars_Users_LoginUserId",
                table: "BooksStars");

            migrationBuilder.DropIndex(
                name: "IX_BooksStars_LoginUserId",
                table: "BooksStars");

            migrationBuilder.AlterColumn<int>(
                name: "LoginUserId",
                table: "BooksStars",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
