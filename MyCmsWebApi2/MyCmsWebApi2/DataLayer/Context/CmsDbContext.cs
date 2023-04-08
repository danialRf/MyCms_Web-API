﻿using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.DataLayer.Model;


namespace MyCmsWebApi2.DataLayer.Context
{
    public class CmsDbContext : DbContext
    {

        public CmsDbContext(DbContextOptions<CmsDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<AdminLogIn> AdminLogin { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<NewsGroup> NewsGroup { get; set; }
        public DbSet<News> News { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CmsDbContext).Assembly);
        }
    }
}