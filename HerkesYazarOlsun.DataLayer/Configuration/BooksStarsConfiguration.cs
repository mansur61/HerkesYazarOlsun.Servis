using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class BooksStarsConfiguration : IEntityTypeConfiguration<BooksStars>
{
    public void Configure(EntityTypeBuilder<BooksStars> builder)
    {
        builder.HasOne(ws => ws.LoginUser)
               .WithMany(u => u.BooksStarsList)
               .HasForeignKey(ws => ws.LoginUserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bs => bs.Book)
               .WithMany(b => b.BooksStars)
               .HasForeignKey(bs => bs.BookId);
    }
}
