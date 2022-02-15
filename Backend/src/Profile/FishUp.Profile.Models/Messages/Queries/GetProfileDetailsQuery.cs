using FishUp.Dispatchers;
using FishUp.Profile.Models.Responses;

namespace FishUp.Profile.Models.Messages.Queries
{
    public record GetProfileDetailsQuery(Guid UserId) : IQuery<ProfileDetails>;
}