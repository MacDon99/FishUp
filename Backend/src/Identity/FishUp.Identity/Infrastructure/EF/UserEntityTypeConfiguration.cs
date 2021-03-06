using FishUp.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishUp.Identity.Infrastructure.EF
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public string Table => "Users";
        public string Schema => "identity";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(Table, Schema);
            builder.HasKey(entity => entity.Id);
        }
    }
}