namespace FishUp.Models.Types
{
    public class Comment : LikeableType
    {
        public int Message { get; set; }
        public Guid AuthorId { get; set; }
    }
}
