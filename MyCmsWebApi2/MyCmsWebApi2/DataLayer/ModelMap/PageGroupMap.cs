using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.ModelMap;

public class PageGroupMap:IEntityTypeConfiguration<PageGroup>
{
    public void Configure(EntityTypeBuilder<PageGroup> builder)
    {
        builder.ToTable("Page Groups");

        builder.HasKey(p => p.PageGroupId);

        builder.Property(p => p.GroupTitle)
            .IsRequired()
            .HasMaxLength(75);

        builder.HasOne(p => p.images)
            .WithOne(p => p.pageGroup)
            .HasForeignKey<Images>(p => p.PageGrupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}