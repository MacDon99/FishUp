
using FishUp.Mailing.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Mailing.Models
{
    public class MailingDbContext : DbContext
    {
        public MailingDbContext(DbContextOptions<MailingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmailMessageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentEntityTypeConfiguration());
        }

        public DbSet<EmailMessage> EmailMessages { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
    }
}
