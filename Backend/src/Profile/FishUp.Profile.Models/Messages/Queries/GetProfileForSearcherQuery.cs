using FishUp.Dispatchers;
using FishUp.Profile.Models.Responses.Queries;

namespace FishUp.Profile.Models.Messages.Queries
{
    public class GetProfileForSearcherQuery : IQuery<ProfileForSearcher>
    {
        public string SearchPhrase { get; set; }
    }
}
