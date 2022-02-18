namespace FishUp.Trip.Models.Responses.Queries
{
    public class CreatedTrip
    {
        public Guid Id { get; set; }
        public string Destination { get; set; }
        public string Author { get; set; }
        public int ParticipantsCount { get; set; }
    }
}
