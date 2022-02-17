using FishUp.Dispatchers;

namespace FishUp.Profile.Models.Responses.Queries
{
    public class ProfilesForSearcher : IQueryResponse
    {
        public IEnumerable<ProfileForSearcher> Profiles { get; set; }
    }
}
