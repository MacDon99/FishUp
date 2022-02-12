
using FishUp.Post.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using PostEntity = FishUp.Post.Models.Entities.Post;

namespace FishUp.Post.Models
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CommentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
        }

        public DbSet<PostEntity> Posts { get; set; }
    }
}
