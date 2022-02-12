using FishUp.Domain;
using FishUp.Domain.Types;
using FishUp.Models.Types;

namespace FishUp.Trip.Models.Entities
{
    public class Trip : Entity
    {
        public string Destination { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Closed { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Comment> Comments { get; set; }

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
            Comments.Add(new Comment(userId, message));
        }

        public void Participate(Guid userId)
        {
            Participants.Add(new Participant(userId, Id));
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
