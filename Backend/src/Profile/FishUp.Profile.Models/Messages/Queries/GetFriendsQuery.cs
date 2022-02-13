using FishUp.Dispatchers;
using FishUp.Profile.Models.Responses;

namespace FishUp.Profile.Models.Messages.Queries
{
    public record GetFriendsQuery(Guid UserId) : IQuery<Friendships>;
}
