using FishUp.Dispatchers;

namespace FishUp.Post.Models.Messages.Commands
{
    public record UndislikePostCommand(Guid UserId, Guid PostId) : ICommand;
}
