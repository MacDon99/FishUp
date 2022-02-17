using FishUp.Dispatchers;

namespace FishUp.Profile.Models.Responses.Queries
{
    public class ProfileDetails : IQueryResponse
    {
        public string FullName { get; set; }
        public string City { get; set; }
        public string Voivodeship { get; set; }
        public int BirthYear { get; set; }
        public string Profession { get; set; }
        public bool WillToTravelFar { get; set; }
        public IEnumerable<Guid> FriendsIds { get; set; }
    }
}
