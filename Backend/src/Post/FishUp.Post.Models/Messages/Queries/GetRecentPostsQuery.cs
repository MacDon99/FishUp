using FishUp.Dispatchers;
using FishUp.Post.Models.Responses.Queries;

namespace FishUp.Post.Models.Messages.Queries
{
    public record GetRecentPostsQuery() : IQuery<RecentPosts>;
}
