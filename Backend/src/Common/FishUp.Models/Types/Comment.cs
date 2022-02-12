namespace FishUp.Models.Types
{
    public class Comment : LikeableType
    {
        public string Message { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PostId { get; set; }
        public Guid TripId { get; set; }

        protected Comment()
        { 
        
        }

        public Comment(Guid userId, string message)
        {

        }
    }
}
