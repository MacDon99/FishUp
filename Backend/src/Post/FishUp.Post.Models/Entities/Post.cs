using FishUp.Domain;
using FishUp.Domain.Types;
using FishUp.Models.Types;

namespace FishUp.Post.Models.Entities
{
    public class Post : LikeableEntity
    {
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public Post(string content, Guid authorId)
        {
            Content = content;
            AuthorId = authorId;
        }

        public void AddComent(Comment comment)
        {
            if (Comments is null)
            { 
                Comments = new List<Comment>();
            }
            Comments.Add(comment);

            Valid();
        }

        public override void Valid()
        {
            if (Content is null)
            {
                throw new DomainException(ExceptionCode.CanNotBeNull, "Post content cannot be null");
            }
        }
    }
}
