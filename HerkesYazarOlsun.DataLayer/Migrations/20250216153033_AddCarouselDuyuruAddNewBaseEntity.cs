using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddCarouselDuyuruAddNewBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CREATE_AT",
                table: "CarouselDuyuru",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IS_DELETED",
                table: "CarouselDuyuru",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "IS_MODIFIED",
                table: "CarouselDuyuru",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "MODIFIED_AT",
                table: "CarouselDuyuru",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OLUSTURAN_EMAIL",
                table: "CarouselDuyuru",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "USER_CREATED_ID",
                table: "CarouselDuyuru",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "USER_MODIFIED_ID",
                table: "CarouselDuyuru",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "USER_MODIFIED_MAIL",
                table: "CarouselDuyuru",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATE_AT",
                table: "CarouselDuyuru");

            migrationBuilder.DropColumn(
                name: "IS_DELETED",
                table: "CarouselDuyuru");

            migrationBuilder.DropColumn(
                name: "IS_MODIFIED",
                table: "CarouselDuyuru");

            migrationBuilder.DropColumn(
                name: "MODIFIED_AT",
                table: "CarouselDuyuru");

            migrationBuilder.DropColumn(
                name: "OLUSTURAN_EMAIL",
                table: "CarouselDuyuru");

            migrationBuilder.DropColumn(
                name: "USER_CREATED_ID",
                table: "CarouselDuyuru");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_ID",
                table: "CarouselDuyuru");

            migrationBuilder.DropColumn(
                name: "USER_MODIFIED_MAIL",
                table: "CarouselDuyuru");
        }
    }
}
