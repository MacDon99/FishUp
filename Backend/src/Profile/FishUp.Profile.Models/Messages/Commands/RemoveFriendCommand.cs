using FishUp.Dispatchers;

namespace FishUp.Profile.Models.Messages.Commands
{
    public record RemoveFriendCommand(Guid UserId, Guid FriendId) : ICommand;
}
