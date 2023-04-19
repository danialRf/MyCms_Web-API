using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Persistences.EF.ModelMap;

public class CommentMap : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.CommentWriterName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.CommentWriterEmail)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.CommentSubject)
            .HasMaxLength(150);

        builder.Property(p => p.CommentText)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(p => p.News)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.NewsId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}