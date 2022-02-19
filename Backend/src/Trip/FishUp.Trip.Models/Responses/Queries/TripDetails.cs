using FishUp.Dispatchers;
using FishUp.Models.Types;

namespace FishUp.Trip.Models.Responses.Queries
{
    public class TripDetails : IQueryResponse
    {
        public Guid Id{ get; set; }
        public string Destination { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Closed { get; set; }
        public ICollection<JoinedParticipant> Participants { get; set; }
        public ICollection<AddedComment> Comments { get; set; }
        public IEnumerable<Guid> LikersIds { get; set; }
        public IEnumerable<Guid> DisLikersIds { get; set; }
        public int LikesCount { get; set; }
        public int DisLikesCount { get; set; }
    }
}
