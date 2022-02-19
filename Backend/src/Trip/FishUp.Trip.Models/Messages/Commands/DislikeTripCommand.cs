using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Messages.Commands
{
    public record DislikeTripCommand(Guid UserId, Guid TripId) : ICommand;
}
