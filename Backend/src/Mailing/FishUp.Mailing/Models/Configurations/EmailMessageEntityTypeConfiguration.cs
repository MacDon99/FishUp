using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishUp.Mailing.Models.Configurations
{
    public class EmailMessageEntityTypeConfiguration : IEntityTypeConfiguration<EmailMessage>
    {
        public string Table => "EmailMessages";
        public string Schema => "mailing";

        public void Configure(EntityTypeBuilder<EmailMessage> builder)
        {
            builder.ToTable(Table, Schema);
            builder.HasKey(entity => entity.Id);
        }
    }
}
