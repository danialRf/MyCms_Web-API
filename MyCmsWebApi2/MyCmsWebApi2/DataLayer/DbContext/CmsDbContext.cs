using Microsoft.EntityFrameworkCore;
using MyCmsWebApi.Models;
using System.Xml;

namespace MyCmsWebApi
{
    public class CmsDbContext : DbContext
    {

        public CmsDbContext(DbContextOptions<CmsDbContext> options) : base(options) { }

     


        public DbSet<AdminLogIn> AdminLogIn { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CmsDbContext).Assembly);
        }
    }
}