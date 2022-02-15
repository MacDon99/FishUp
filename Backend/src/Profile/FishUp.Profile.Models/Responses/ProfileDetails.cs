using FishUp.Dispatchers;

namespace FishUp.Profile.Models.Responses
{
    public class ProfileDetails : IQueryResponse
    {
        public string FullName { get; set; }
    }
}
