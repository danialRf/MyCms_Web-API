using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Persistences.EF.ModelMap
{
    public class CommentLikeMap : IEntityTypeConfiguration<CommentLike>
    {
        public void Configure(EntityTypeBuilder<CommentLike> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
