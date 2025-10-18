using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

public class BooksPagesConfiguration : IEntityTypeConfiguration<BooksPages>
{
    public void Configure(EntityTypeBuilder<BooksPages> builder)
    {
        builder.HasOne(bp => bp.Book)
               .WithMany()
               .HasForeignKey(bp => bp.BookId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
