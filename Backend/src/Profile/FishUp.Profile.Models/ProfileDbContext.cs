
using FishUp.Domain.Types;
using FishUp.Post.Models.Configurations;
using FishUp.Profile.Models.Configurations;
using FishUp.Profile.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Profile.Models
{
    public class ProfileDbContext : DbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FriendEntityTypeConfiguration());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
    }
}
