using Microsoft.EntityFrameworkCore;
using MyCmsWebApi.Models;

namespace MyCmsWebApi.DataLayer.DbContext
{
    public class CmsDbContext : DbContext
    {

        public CmsDbContext
                (DbContextOptions<CmsDbContext> options)
                : base(options)
        {

        }


        public DbSet<AdminLogIn> AdminLogIn { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CmsDbContext).Assembly);
        }
    }
}