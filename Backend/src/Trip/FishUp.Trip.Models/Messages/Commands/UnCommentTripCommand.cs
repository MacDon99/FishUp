using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Messages.Commands
{
    public record UnCommentTripCommand(Guid UserId, Guid TripId, Guid CommentId) : ICommand;
}
