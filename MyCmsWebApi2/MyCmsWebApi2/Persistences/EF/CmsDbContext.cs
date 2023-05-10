using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Persistences.EF
{
    public class CmsDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

        public CmsDbContext(DbContextOptions<CmsDbContext> options) : base(options)
        {

        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<NewsGroup> NewsGroup { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CmsDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}