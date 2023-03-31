using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.ModelMap;

public class PageMap:IEntityTypeConfiguration<Page>
{
    public void Configure(EntityTypeBuilder<Page> builder)
    {
        builder.ToTable("Page");

        builder.HasKey(p => p.PageId);

        builder.Property(p => p.PageGroupId)
            .IsRequired();

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.ShortDescription)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Text)
            .HasMaxLength(10000)
            .IsRequired();

        builder.Property(p => p.Visit)
            .IsRequired();

        builder.Property(p => p.ShowInSlider)
            .IsRequired();

        builder.Property(p => p.CreateDate)
            .IsRequired();

        builder.Property(p => p.Tags)
            .HasMaxLength(300);

        builder.HasOne(p => p.comments)
            .WithOne(p => p.page)
            .HasForeignKey<Comments>(p => p.PageId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.pageGroup)
            .WithMany(p => p.page)
            .HasForeignKey(p => p.PageGroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}