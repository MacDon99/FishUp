using FishUp.Dispatchers;

namespace FishUp.Post.Models.Messages.Commands
{
    public record LikePostCommand(Guid UserId, Guid postId) : ICommand;
}
