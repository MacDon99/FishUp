namespace FishUp.Models.Types
{
    public class AddedComment
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Message { get; set; }
    }
}
