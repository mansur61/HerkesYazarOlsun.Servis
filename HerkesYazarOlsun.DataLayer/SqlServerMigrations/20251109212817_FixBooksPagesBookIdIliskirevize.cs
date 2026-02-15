using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class FixBooksPagesBookIdIliskirevize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eğer foreign key ya da index kalmadıysa, sadece kolon sil.
            // Bu işlem, constraint zaten yoksa hata vermez.
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_BooksPages_Books_BooksID')
                    ALTER TABLE BooksPages DROP CONSTRAINT [FK_BooksPages_Books_BooksID];
                
                IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_BooksPages_BooksID')
                    DROP INDEX [IX_BooksPages_BooksID] ON [BooksPages];
                
                IF EXISTS (SELECT 1 FROM sys.columns WHERE Name = N'BooksID' AND Object_ID = Object_ID(N'BooksPages'))
                    ALTER TABLE [BooksPages] DROP COLUMN [BooksID];
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Geri alma işlemi (Down) kısmını istersen tutabiliriz,
            // ama BooksID'yi bir daha kullanmayacağımız için basitleştirdik.
            migrationBuilder.AddColumn<long>(
                name: "BooksID",
                table: "BooksPages",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksPages_BooksID",
                table: "BooksPages",
                column: "BooksID");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksPages_Books_BooksID",
                table: "BooksPages",
                column: "BooksID",
                principalTable: "Books",
                principalColumn: "ID");
        }
    }
}
