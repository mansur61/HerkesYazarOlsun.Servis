using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addedkolonaccountlogintable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowRefresh",
                table: "AccountLogin",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresUtc",
                table: "AccountLogin",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPersistent",
                table: "AccountLogin",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowRefresh",
                table: "AccountLogin");

            migrationBuilder.DropColumn(
                name: "ExpiresUtc",
                table: "AccountLogin");

            migrationBuilder.DropColumn(
                name: "IsPersistent",
                table: "AccountLogin");
        }
    }
}
