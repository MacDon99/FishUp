using FishUp.Dispatchers;
using FishUp.Models.Types;

namespace FishUp.Post.Models.Responses.Queries
{
    public class PostDetails : IQueryResponse
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public IEnumerable<AddedComment> Comments { get; set; }
        public IEnumerable<Guid> LikersIds { get; set; }
        public IEnumerable<Guid> DisLikersIds { get; set; }
        public int LikesCount { get; set; }
        public int DisLikesCount { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
    }
}
