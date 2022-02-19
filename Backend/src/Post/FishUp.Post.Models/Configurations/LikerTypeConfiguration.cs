using FishUp.Models.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishUp.Post.Models.Configurations
{
    public class LikerTypeConfiguration : IEntityTypeConfiguration<Liker>
    {
        public string Table => "Likers";
        public string Schema => "post";

        public void Configure(EntityTypeBuilder<Liker> builder)
        {
            builder.ToTable(Table, Schema);
            builder.HasKey(entity => entity.Id);
        }
    }
}
