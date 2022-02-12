using FishUp.Dispatchers;
using Microsoft.AspNetCore.Http;

namespace FishUp.Post.Models.Messages.Commands
{
    public record UpdatePostCommand(Guid UserId, Guid PostId, string Message, IEnumerable<IFormFile>? Photos) : ICommand;
}
