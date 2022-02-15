using FishUp.Dispatchers;
using FishUp.Profile.Models.Responses.Queries;

namespace FishUp.Profile.Models.Messages.Queries
{
    public record GetFriendsQuery(Guid UserId) : IQuery<Friendships>;
}
