using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddNewBaseEntitySponsorlarDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CREATE_AT",
                table: "Sponsorlar",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IS_DELETED",
                table: "Sponsorlar",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "IS_MODIFIED",
                table: "Sponsorlar",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "MODIFIED_AT",
                table: "Sponsorlar",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAIL",
                table: "Sponsorlar",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "USER_CREATED_ID",
                table: "Sponsorlar",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "USER_MODIFIED_ID",
                table: "Sponsorlar",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "Sponsorlar",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATE_AT",
                table: "Sponsorlar");

            migrationBuilder.DropColumn(
                name: "IS_DELETED",
                table: "Sponsorlar");

            migrationBuilder.DropColumn(
                name: "IS_MODIFIED",
                table: "Sponsorlar");

            migrationBuilder.DropColumn(
                name: "MODIFIED_AT",
                table: "Sponsorlar");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAIL",
                table: "Sponsorlar");

            migrationBuilder.DropColumn(
                name: "USER_CREATED_ID",
                table: "Sponsorlar");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_ID",
                table: "Sponsorlar");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "Sponsorlar");
        }
    }
}
