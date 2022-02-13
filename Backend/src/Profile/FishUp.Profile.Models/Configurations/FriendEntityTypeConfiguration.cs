using FishUp.Profile.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishUp.Profile.Models.Configurations
{
    public class FriendEntityTypeConfiguration : IEntityTypeConfiguration<Friend>
    {
        public string Table => "Friends";
        public string Schema => "profile";

        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable(Table, Schema);
            builder.HasKey(entity => entity.Id);
        }
    }
}
