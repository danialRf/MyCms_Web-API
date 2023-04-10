using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.ModelMap;

public class ImagesMap:IEntityTypeConfiguration<Images>
{
    public void Configure(EntityTypeBuilder<Images> builder)
    {
        builder.ToTable("Images");

        builder.HasKey(p => p.Id);

        builder.Property(p=>p.Base64).IsRequired();

        builder.Property(p => p.ImageName)
            .IsRequired();

        builder.HasOne(p => p.News)
            .WithMany(p => p.Images)
            .HasForeignKey(p => p.NewsId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}