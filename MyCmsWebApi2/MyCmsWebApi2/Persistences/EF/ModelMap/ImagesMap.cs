using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Persistences.EF.ModelMap;

public class ImagesMap : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Base64).IsRequired();
        builder.Property(p => p.ContentType).HasMaxLength(256);

        builder.Property(p => p.ImageName)
            .IsRequired();
    }
}