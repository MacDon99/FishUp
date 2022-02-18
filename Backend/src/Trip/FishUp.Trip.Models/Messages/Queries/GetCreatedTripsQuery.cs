using FishUp.Dispatchers;
using FishUp.Trip.Models.Responses.Queries;

namespace FishUp.Trip.Models.Messages.Queries
{
    public record GetCreatedTripsQuery(Guid UserId) : IQuery<CreatedTrips>;
}
