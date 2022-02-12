using FishUp.Models.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishUp.Trip.Models.Configurations
{
    public class CommentTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public string Table => "Comments";
        public string Schema => "mutual";

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(Table, Schema);
            builder.HasKey(entity => entity.Id);
        }
    }
}
