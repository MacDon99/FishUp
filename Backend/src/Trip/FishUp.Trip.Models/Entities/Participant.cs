using FishUp.Domain;

namespace FishUp.Trip.Models.Entities
{
    public class Participant : Entity
    {
        public Guid UserId { get; set; }
        public Guid TripId { get; set; }

        protected Participant()
        { 
        
        }

        public Participant(Guid userId, Guid tripId)
        {
            UserId = userId;
            TripId = tripId;
        }
        
        public override void Valid()
        {
        }
    }
}
