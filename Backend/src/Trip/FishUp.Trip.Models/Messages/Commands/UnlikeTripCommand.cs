using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Messages.Commands
{
    public record UnlikeTripCommand(Guid UserId, Guid TripId) : ICommand;
}
