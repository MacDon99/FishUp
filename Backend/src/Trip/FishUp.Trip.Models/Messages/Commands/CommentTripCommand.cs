using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Messages.Commands
{
    public record CommentTripCommand(Guid UserId, Guid TripId, string Message) : ICommand;
}
