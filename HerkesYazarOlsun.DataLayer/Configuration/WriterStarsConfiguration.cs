using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
public class WriterStarsConfiguration : IEntityTypeConfiguration<WriterStars>
{
    public void Configure(EntityTypeBuilder<WriterStars> builder)
    {
        builder.HasOne(ws => ws.YazarUsers)
               .WithMany(u => u.WriterStarsYazarList)
               .HasForeignKey(ws => ws.YazarId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ws => ws.LoginUsers)
               .WithMany(u => u.WriterStarsLoginList)
               .HasForeignKey(ws => ws.LoginUserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
