namespace FishUp.Trip.Models.Responses.Queries
{
    public class AvailableTrip
    {
        public string Destination { get; set; }
        public string Author { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Closed { get; set; }
        public ICollection<JoinedParticipant> Participants { get; set; }
    }
}
