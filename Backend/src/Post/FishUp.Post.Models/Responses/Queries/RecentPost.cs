namespace FishUp.Post.Models.Responses.Queries
{
    public class RecentPost
    {
        public Guid PostId { get; set; }
        public string Message { get; set; }
        public string AuthorName { get; set; }
    }
}
