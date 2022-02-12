using FishUp.Dispatchers;

namespace FishUp.Post.Models.Responses.Queries
{
    public class CreatedPosts : IQueryResponse
    {
        public IEnumerable<CreatedPost> Posts { get; set;}
    }
}
