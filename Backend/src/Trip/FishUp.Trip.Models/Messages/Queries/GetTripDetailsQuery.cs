using FishUp.Dispatchers;
using FishUp.Trip.Models.Responses.Queries;

namespace FishUp.Trip.Models.Messages.Queries
{
    public record GetTripDetailsQuery(Guid TripId, Guid UserId) : IQuery<TripDetails>;
}
