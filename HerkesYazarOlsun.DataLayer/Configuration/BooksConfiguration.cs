using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

public class BooksConfiguration : IEntityTypeConfiguration<Books>
{
    public void Configure(EntityTypeBuilder<Books> builder)
    {
        builder.HasOne(b => b.Categories)
               .WithMany()
               .HasForeignKey(b => b.CategoriId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(b => b.BookYayinAyari)
               .WithMany()
               .HasForeignKey(b => b.YayinAyarId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.BooksPageList)
               .WithOne(p => p.Book)
               .HasForeignKey(p => p.BooksId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(b => b.User)
               .WithMany()
               .HasForeignKey(b => b.YazarId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.BooksComments)
               .WithOne(p => p.Books)
               .HasForeignKey(p => p.BookId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(b => b.BooksDegerlendirme)
               .WithOne(p => p.Books)
               .HasForeignKey(p => p.BookId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(b => b.BooksStars)
               .WithOne(p => p.Books)
               .HasForeignKey(p => p.BookId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
