using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
namespace HerkesYazarOlsun.DataLayer.Context;
public static class MakaleMapping
{
    public static void ConfigureMakaleler(this ModelBuilder builder)
    {
        var article = builder.Entity<Makale>();
        article.ToTable("Makaleler");
        article.HasKey(x => x.Id);
        article.Property(x => x.Baslik).HasMaxLength(200).IsRequired();
        article.Property(x => x.Yazar).HasMaxLength(200).IsRequired();
        article.Property(x => x.Uzanti).HasMaxLength(10).IsRequired();
        article.HasOne<Users>().WithMany().HasForeignKey(x => x.YazarId).OnDelete(DeleteBehavior.Restrict);
        article.HasIndex(x => new { x.YayinTarihi, x.Id });
        article.HasIndex(x => new { x.YazarId, x.YayinTarihi, x.Id });
        var document = builder.Entity<MakaleBelge>();
        document.ToTable("MakaleBelgeler");
        document.HasKey(x => x.Id);
        document.HasOne<Makale>().WithOne().HasForeignKey<MakaleBelge>(x => x.Id).OnDelete(DeleteBehavior.Cascade);
    }
}
