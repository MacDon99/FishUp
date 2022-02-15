using FishUp.Models.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishUp.Profile.Models.Configurations
{
    public class StoredFileEntityTypeConfiguration : IEntityTypeConfiguration<StoredFile>
    {
        public string Table => "Files";
        public string Schema => "mutual";

        public void Configure(EntityTypeBuilder<StoredFile> builder)
        {
            builder.ToTable(Table, Schema);
            builder.HasKey(entity => entity.Id);
        }
    }
}
