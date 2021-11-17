using FishUp.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IdentityEfCore = Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FishUp.Identity.Infrastructure.EF
{
    public class IdentityDbContext : IdentityEfCore.IdentityDbContext<AppIdentityUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }

        public DbSet<User> Users { get; set; }
    }
}