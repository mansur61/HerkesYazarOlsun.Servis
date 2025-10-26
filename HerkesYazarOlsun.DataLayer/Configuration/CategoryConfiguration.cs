using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasOne(c => c.CategoryYayinAyarlari)
           .WithOne(a => a.Category)
           .HasForeignKey<CategoryYayinAyarlari>(a => a.CategoryId);
    }
}
