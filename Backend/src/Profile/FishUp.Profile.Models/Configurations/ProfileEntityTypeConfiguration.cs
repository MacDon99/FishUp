using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfileEntity = FishUp.Profile.Models.Entities.Profile;

namespace FishUp.Profile.Models.Configurations
{
    public class ProfileEntityTypeConfiguration : IEntityTypeConfiguration<ProfileEntity>
    {
        public string Table => "Profiles";
        public string Schema => "profile";

        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder.ToTable(Table, Schema);
            builder.HasKey(entity => entity.Id);
        }
    }
}
