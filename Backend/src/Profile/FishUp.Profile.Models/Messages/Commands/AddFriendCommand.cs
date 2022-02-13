using FishUp.Dispatchers;

namespace FishUp.Profile.Models.Messages.Commands
{
    public record AddFriendCommand(Guid UserId, Guid FriendId) : ICommand;
}
