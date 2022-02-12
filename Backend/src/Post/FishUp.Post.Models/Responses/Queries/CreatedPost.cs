using FishUp.Models.Types;

namespace FishUp.Post.Models.Responses.Queries
{
    public class CreatedPost
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
        public int LikesCount { get; set; }
        public int DislikesCount { get; set; }
    }
}
