using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripEntity = FishUp.Trip.Models.Entities.Trip;

namespace FishUp.Trip.Models.Configurations
{
    public class TripEntityTypeConfiguration : IEntityTypeConfiguration<TripEntity>
    {
        public string Table => "Trips";
        public string Schema => "trip";

        public void Configure(EntityTypeBuilder<TripEntity> builder)
        {
            builder.ToTable(Table, Schema);
            builder.HasKey(entity => entity.Id);
        }
    }
}
