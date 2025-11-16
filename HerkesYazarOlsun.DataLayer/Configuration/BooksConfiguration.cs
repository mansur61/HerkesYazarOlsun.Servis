using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

public class BooksConfiguration : IEntityTypeConfiguration<Books>
{
    public void Configure(EntityTypeBuilder<Books> builder)
    {
        builder.HasOne(b => b.Categori)
               .WithMany()
               .HasForeignKey(b => b.CategoriId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.YayinAyar)
       .WithOne(ya => ya.Book)
       .HasForeignKey<YayinAyarlari>(ya => ya.BookId)
       .OnDelete(DeleteBehavior.Restrict);


        builder.HasMany(b => b.BooksPageList)
               .WithOne(p => p.Book)
               .HasForeignKey(p => p.BookId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(b => b.Yazar)
               .WithMany()
               .HasForeignKey(b => b.YazarId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.BooksComments)
               .WithOne(p => p.Book)
               .HasForeignKey(p => p.BookId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(b => b.BooksDegerlendirme)
               .WithOne(p => p.Book)
               .HasForeignKey(p => p.BookId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(b => b.BooksStars)
               .WithOne(p => p.Book)
               .HasForeignKey(p => p.BookId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
