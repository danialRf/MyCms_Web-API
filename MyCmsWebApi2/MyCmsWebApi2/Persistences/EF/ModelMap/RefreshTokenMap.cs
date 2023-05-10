using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Persistences.EF.ModelMap
{
    public class RefreshTokenMap : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.JwtId)
             .IsRequired();
            builder.Property(p => p.Token)
            .IsRequired();
            builder.Property(p => p.UserId)
            .IsRequired();

            

        }
    }
}
