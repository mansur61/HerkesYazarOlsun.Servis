using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
public class WriterStarsConfiguration : IEntityTypeConfiguration<WriterStars>
{
    public void Configure(EntityTypeBuilder<WriterStars> builder)
    {
        // Yazar (beğenilenler) ↔ WriterStarsYazarList
        builder.HasOne(ws => ws.Yazar)
               .WithMany(u => u.WriterStarsYazarList)
               .HasForeignKey(ws => ws.YazarId)
               .OnDelete(DeleteBehavior.NoAction);

        // LoginUser (beğenenler) ↔ WriterStarsLoginList
        builder.HasOne(ws => ws.LoginUser)
               .WithMany(u => u.WriterStarsLoginList)
               .HasForeignKey(ws => ws.LoginUserId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
