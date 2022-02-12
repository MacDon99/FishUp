using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Responses.Queries
{
    public class AvailableTrips : IQueryResponse
    {
        public IEnumerable<AvailableTrip> Trips { get; set; }
    }
}
