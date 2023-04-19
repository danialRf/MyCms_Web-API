using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Persistences.EF.ModelMap;

public class MyUserMap : IEntityTypeConfiguration<MyUser>
{
    public void Configure(EntityTypeBuilder<MyUser> builder)
    {
    }
}

