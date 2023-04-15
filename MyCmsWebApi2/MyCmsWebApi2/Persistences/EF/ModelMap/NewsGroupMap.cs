using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.DataLayer.Model;


namespace MyCmsWebApi2.Persistences.EF.ModelMap;

public class NewsGroupMap : IEntityTypeConfiguration<NewsGroup>
{
    public void Configure(EntityTypeBuilder<NewsGroup> builder)
    {
        builder.ToTable("NewsGroup");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.GroupTitle)
            .IsRequired()
            .HasMaxLength(75);

    }
}