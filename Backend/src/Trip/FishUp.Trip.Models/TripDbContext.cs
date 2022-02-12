
using FishUp.Domain.Types;
using FishUp.Models.Types;
using FishUp.Trip.Models.Configurations;
using FishUp.Trip.Models.Entities;
using Microsoft.EntityFrameworkCore;
using TripEntity = FishUp.Trip.Models.Entities.Trip;

namespace FishUp.Post.Models
{
    public class TripDbContext : DbContext
    {
        public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TripEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ParticipantEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CommentTypeConfiguration());
        }

        public DbSet<TripEntity> Trips { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
