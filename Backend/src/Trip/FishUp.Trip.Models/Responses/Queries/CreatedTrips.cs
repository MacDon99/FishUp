using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Responses.Queries
{
    public class CreatedTrips : IQueryResponse
    {
        public IEnumerable<CreatedTrip> Trips { get; set; }
    }
}
