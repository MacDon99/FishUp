using FishUp.Dispatchers;
using FishUp.Post.Models.Responses.Queries;

namespace FishUp.Post.Models.Messages.Queries
{
    public record GetPostDetailsQuery(Guid PostId) : IQuery<PostDetails>;
}
