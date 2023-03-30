using Microsoft.EntityFrameworkCore;

namespace MyCmsWebApi.DataLayer.DbContext;

public class CmsDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public CmsDbContext()
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CmsDbContext).Assembly);
    }
}