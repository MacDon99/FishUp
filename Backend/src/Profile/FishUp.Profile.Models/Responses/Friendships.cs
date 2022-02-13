using FishUp.Dispatchers;

namespace FishUp.Profile.Models.Responses
{
    public class Friendships : IQueryResponse
    {
        public IEnumerable<UserFriend> UserFriends { get; set; }
    }
}
