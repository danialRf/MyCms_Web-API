using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.DataLayer.Model;


namespace MyCmsWebApi2.DataLayer.Context
{
    public class CmsDbContext : DbContext
    {

        public CmsDbContext(DbContextOptions<CmsDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<AdminLogIn> adminLogin { get; set; }
        public DbSet<Comments> comments { get; set; }
        public DbSet<Images> images { get; set; }
        public DbSet<PageGroup> pageGroup { get; set; }
        public DbSet<Page> page { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CmsDbContext).Assembly);
        }
    }
}