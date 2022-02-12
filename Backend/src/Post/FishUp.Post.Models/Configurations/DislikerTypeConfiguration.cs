using FishUp.Post.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishUp.Post.Models.Configurations
{
    public class DislikerTypeConfiguration : IEntityTypeConfiguration<Disliker>
    {
        public string Table => "Dislikers";
        public string Schema => "post";

        public void Configure(EntityTypeBuilder<Disliker> builder)
        {
            builder.ToTable(Table, Schema);
            builder.HasKey(entity => entity.Id);
        }
    }
}
