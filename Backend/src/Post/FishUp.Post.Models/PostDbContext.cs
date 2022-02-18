
using FishUp.Domain.Types;
using FishUp.Post.Models.Configurations;
using FishUp.Post.Models.Entities;
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
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CommentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StoredFileEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LikerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DislikerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FriendEntityTypeConfiguration());
        }

        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
    }
}
