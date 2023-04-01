using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.ModelMap;

public class ImagesMap:IEntityTypeConfiguration<Images>
{
    public void Configure(EntityTypeBuilder<Images> builder)
    {
        builder.ToTable("Images");

        builder.HasKey(p => p.ImagesId);

        builder.Property(p => p.ImageName)
            .IsRequired();

        builder.HasOne(p => p.page)
            .WithMany(p => p.images)
            .HasForeignKey(p => p.imageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}