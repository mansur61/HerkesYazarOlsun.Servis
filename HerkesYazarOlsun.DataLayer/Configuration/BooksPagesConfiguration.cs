using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

public class BooksPagesConfiguration : IEntityTypeConfiguration<BooksPages>
{
    public void Configure(EntityTypeBuilder<BooksPages> builder)
    {
        builder.HasOne(bp => bp.Book)
                .WithMany(b => b.BooksPageList)  // ✅ ilişkiyi doğru tanımla
                .HasForeignKey(bp => bp.BookId)
                .HasPrincipalKey(b => b.ID)       // ✅ ana anahtar belirtilsin
                .OnDelete(DeleteBehavior.Restrict); // veya Cascade, sana bağlı
    }
}
