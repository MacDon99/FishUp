using FishUp.Dispatchers;

namespace FishUp.Post.Models.Responses.Queries
{
    public class RecentPosts : IQueryResponse
    {
        public IEnumerable<RecentPost> Posts { get; set; }
    }
}
