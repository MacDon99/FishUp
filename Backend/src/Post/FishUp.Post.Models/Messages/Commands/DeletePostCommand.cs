using FishUp.Dispatchers;

namespace FishUp.Post.Models.Messages.Commands
{
    public record DeletePostCommand(Guid UserId, Guid PostId) : ICommand;
}
