using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedaccountlogintable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountLogin",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    RememberLogin = table.Column<bool>(type: "boolean", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    sifre = table.Column<string>(type: "text", nullable: true),
                    benihatirla = table.Column<string>(type: "text", nullable: true),
                    CREATE_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAİL = table.Column<string>(type: "text", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: false),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: false),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "text", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLogin", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountLogin");
        }
    }
}
