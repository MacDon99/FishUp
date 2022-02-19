using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Messages.Commands
{
    public record LikeTripCommand(Guid UserId, Guid TripId) : ICommand;
}
