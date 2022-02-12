using FishUp.Dispatchers;

namespace FishUp.Post.Models.Messages.Commands
{
    public record UnlikePostCommand(Guid UserId, Guid postId) : ICommand;
}
