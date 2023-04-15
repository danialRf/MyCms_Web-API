using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Persistences.EF.ModelMap;

public class AdminLogInMap : IEntityTypeConfiguration<AdminLogIn>
{
    public void Configure(EntityTypeBuilder<AdminLogIn> builder)
    {
        builder.ToTable("AdminLogin");

        builder.HasKey(p => p.Id);

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

