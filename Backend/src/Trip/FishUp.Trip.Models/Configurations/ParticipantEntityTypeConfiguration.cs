using FishUp.Trip.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishUp.Trip.Models.Configurations
{
    public class ParticipantEntityTypeConfiguration : IEntityTypeConfiguration<Participant>
    {
        public string Table => "Participants";
        public string Schema => "trip";

        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable(Table, Schema);
            builder.HasKey(entity => entity.Id);
        }
    }
}
