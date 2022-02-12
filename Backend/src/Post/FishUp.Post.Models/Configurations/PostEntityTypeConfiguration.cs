using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostEntity = FishUp.Post.Models.Entities.Post;

namespace FishUp.Post.Models.Configurations
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public string Table => "Posts";
        public string Schema => "post";

        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable(Table, Schema);
            builder.HasKey(entity => entity.Id);
        }
    }
}
