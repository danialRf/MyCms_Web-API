using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.ModelMap;

public class NewsGroupMap:IEntityTypeConfiguration<NewsGroup>
{
    public void Configure(EntityTypeBuilder<NewsGroup> builder)
    {
        builder.ToTable("NewsGroup");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.GroupTitle)
            .IsRequired()
            .HasMaxLength(75);

        builder.HasOne(p => p.Images)
            .WithOne(p => p.NewsGroup)
            .HasForeignKey<Images>(p => p.NewsGroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}