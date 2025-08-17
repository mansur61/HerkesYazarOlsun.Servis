using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class TestSbTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDegisiklik = table.Column<int>(type: "int", nullable: true),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    UserDetailID = table.Column<long>(type: "bigint", nullable: false),
                    ProfileID = table.Column<long>(type: "bigint", nullable: false),
                    BildirimID = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
