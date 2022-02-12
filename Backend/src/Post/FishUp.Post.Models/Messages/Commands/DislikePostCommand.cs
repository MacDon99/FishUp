using FishUp.Dispatchers;

namespace FishUp.Post.Models.Messages.Commands
{
    public record DislikePostCommand(Guid UserId, Guid PostId) : ICommand;
}
