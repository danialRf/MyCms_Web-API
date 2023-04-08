using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.ModelMap;

public class NewsMap:IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.ToTable("News");

        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

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

        
        
        builder.HasOne(p => p.NewsGroup)
            .WithMany(p => p.News)
            .HasForeignKey(p => p.NewsGroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}