using FishUp.Domain;
using FishUp.Domain.Types;
using FishUp.Models.Types;

namespace FishUp.Trip.Models.Entities
{
    public class Trip : LikeableEntity
    {
        public string Destination { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Closed { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Liker> Likers { get; set; }
        public virtual ICollection<Disliker> Dislikers { get; set; }

        protected Trip()
        {

        }

        public Trip(string destination, DateTime startDate, DateTime endDate, Guid authorId)
        {
            Destination = destination;
            StartDate = startDate;
            EndDate = endDate;
            AuthorId = authorId;

            Valid();
        }

        public void Update(string destination, DateTime? startDate = null, DateTime? endDate = null, bool closed = false)
        {
            Destination = Destination;
            StartDate = startDate.HasValue ? startDate.Value : StartDate;
            EndDate = endDate.HasValue ? endDate.Value : EndDate;
            Closed = closed;
        }

        public void Comment(Guid userId, string message)
        {
            if (Comments is null)
            {
                Comments = new List<Comment>();
            }
            Comments.Add(new Comment(userId, message));

            Valid();
        }

        public void Participate(Guid userId)
        {
            if (Participants is null)
            {
                Participants = new List<Participant>();
            }
            Participants.Add(new Participant(userId, Id));
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

        public void Close()
        {
            Closed = true;
            UpdateEntity();
        }

        public override void Valid()
        {
            if (string.IsNullOrEmpty(Destination))
            {
                throw new DomainException(ExceptionCode.CanNotBeNull, "Destination cannot be null");
            }
        }
    }
}
