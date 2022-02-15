
using FishUp.Domain.Types;
using FishUp.Models.Types;
using FishUp.Post.Models.Configurations;
using FishUp.Profile.Models.Configurations;
using FishUp.Profile.Models.Entities;
using Microsoft.EntityFrameworkCore;
using ProfileEntity = FishUp.Profile.Models.Entities.Profile;

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
            modelBuilder.ApplyConfiguration(new ProfileEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StoredFileEntityTypeConfiguration());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<StoredFile> StoredFiles { get; set; }
    }
}
