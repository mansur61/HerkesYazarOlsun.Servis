using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 
public class UsersConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasOne(u => u.Profil)
               .WithOne(p => p.User)
               .HasForeignKey<Profil>(p => p.LoginUserId);
    }
}
