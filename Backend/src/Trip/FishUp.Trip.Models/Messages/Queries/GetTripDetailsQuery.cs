using FishUp.Dispatchers;
using FishUp.Trip.Models.Responses.Queries;

namespace FishUp.Trip.Models.Messages.Queries
{
    public record GetTripDetailsQuery(Guid TripId) : IQuery<TripDetails>;
}
