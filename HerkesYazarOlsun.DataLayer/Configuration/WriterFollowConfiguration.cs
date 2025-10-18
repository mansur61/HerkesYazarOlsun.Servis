using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

public class WriterFollowConfiguration : IEntityTypeConfiguration<WriterFollow>
{
    public void Configure(EntityTypeBuilder<WriterFollow> builder)
    {
        builder.HasOne(wf => wf.Yazar)
               .WithMany(u => u.WriterFollowYazarList)
               .HasForeignKey(wf => wf.YazarId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(wf => wf.LoginUsers)
               .WithMany(u => u.WriterFollowLoginList)
               .HasForeignKey(wf => wf.LoginUserId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
