using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Messages.Commands
{
    public record UpdateTripCommand(Guid UserId, Guid TripId) : ICommand
    {
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Closed { get; set; }
    }
}
