using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.DataLayer.Model;

namespace MyCmsWebApi2.DataLayer.ModelMap;

public class CommentMap:IEntityTypeConfiguration<Comments>
{
    public void Configure(EntityTypeBuilder<Comments> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(p => p.CommentId);

        builder.Property(p => p.CommentName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.CommentEmail)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.CommentSubject)
            .HasMaxLength(150);

        builder.Property(p => p.CommentText)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.HasOne(p => p.page)
            .WithMany(p => p.comments)
            .HasForeignKey(p => p.PageId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}