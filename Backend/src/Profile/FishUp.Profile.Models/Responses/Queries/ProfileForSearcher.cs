using FishUp.Dispatchers;

namespace FishUp.Profile.Models.Responses.Queries
{
    public class ProfileForSearcher : IQueryResponse
    {
        public string FullName { get; set; }
    }
}
