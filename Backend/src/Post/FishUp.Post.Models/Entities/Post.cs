using FishUp.Domain;
using FishUp.Domain.Types;
using FishUp.Models.Types;

namespace FishUp.Post.Models.Entities
{
    public class Post : LikeableEntity
    {
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<StoredFile>? Photos { get; set; }
        public virtual ICollection<Liker> Likers { get; set; }
        public virtual ICollection<Disliker> Dislikers { get; set; }

        protected Post()
        {

        }

        public Post(string content, Guid authorId, IEnumerable<StoredFile>? photos = null)
        {
            Content = content;
            AuthorId = authorId;

            Photos = photos is null ? Photos : photos.ToList();
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

        public void AddPhoto(StoredFile photo)
        {
            if (Photos is null)
            {
                Photos = new List<StoredFile>();
            }
            Photos.Add(photo);
        }

        public void AddLike(Guid likerId)
        { 
            if (Likers is null)
            { 
                Likers = new List<Liker>();
            }

            if (Likers.FirstOrDefault(liker => liker.UserId == likerId) == null)
            {
                LikesCount++;
                Likers.Add(new Liker(likerId));
            }
        }

        public void RemoveLike(Guid likerId)
        {
            if (Likers is not null && Likers.FirstOrDefault(liker => liker.UserId == likerId) != null)
            {
                LikesCount--;
                var likerToRemove = Likers.Single(liker => liker.UserId == likerId);
                Likers.Remove(likerToRemove);
            }
        }

        public void AddDislike(Guid likerId)
        { 
            if (Dislikers is null)
            {
                Dislikers = new List<Disliker>();
            }

            if (Dislikers.FirstOrDefault(liker => liker.UserId == likerId) == null)
            {
                DislikesCount++;
                Dislikers.Add(new Disliker(likerId));
            }
        }

        public void RemoveDislike(Guid likerId)
        {
            if (Dislikers is not null && Dislikers.FirstOrDefault(disliker => disliker.UserId == likerId) != null)
            {
                DislikesCount--;
                var dislikerToRemove = Dislikers.Single(disliker => disliker.UserId == likerId);
                Dislikers.Remove(dislikerToRemove);
            }
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
