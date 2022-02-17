using FishUp.Dispatchers;
using FishUp.Profile.Models.Responses.Queries;

namespace FishUp.Profile.Models.Messages.Queries
{
    public class GetProfilesForSearcherQuery : IQuery<ProfilesForSearcher>
    {
        public string SearchPhrase { get; set; }
    }
}
