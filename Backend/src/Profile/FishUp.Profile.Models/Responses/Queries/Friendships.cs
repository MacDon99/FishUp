using FishUp.Dispatchers;

namespace FishUp.Profile.Models.Responses.Queries
{
    public class Friendships : IQueryResponse
    {
        public IEnumerable<UserFriend> UserFriends { get; set; }
    }
}
