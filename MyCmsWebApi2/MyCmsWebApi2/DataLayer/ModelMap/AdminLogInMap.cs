using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi.Models;

namespace MyCmsWebApi.ModelMap;

public class AdminLogInMap:IEntityTypeConfiguration<AdminLogIn>
{
    public void Configure(EntityTypeBuilder<AdminLogIn> builder)
    {
        builder.ToTable("Admin Login");
        
        builder.HasKey(p => p.LoginId);

        builder.Property(p => p.UserName)
            .HasColumnName("نام کاربری")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("ایمیل");

        builder.Property(p => p.Passwords)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("کلمه عبور");
        
    }
}

