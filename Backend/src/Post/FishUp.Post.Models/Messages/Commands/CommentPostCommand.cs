using FishUp.Dispatchers;

namespace FishUp.Post.Models.Messages.Commands
{
    public record CommentPostCommand : ICommand
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Message { get; set; }
    }
}
