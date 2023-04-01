using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.ModelMap;

public class AdminLogInMap:IEntityTypeConfiguration<AdminLogIn>
{
    public void Configure(EntityTypeBuilder<AdminLogIn> builder)
    {
        builder.ToTable("Admin Login");
        
        builder.HasKey(p => p.LoginId);

        builder.Property(p => p.UserName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Passwords)
            .IsRequired()
            .HasMaxLength(50);
    }
}

