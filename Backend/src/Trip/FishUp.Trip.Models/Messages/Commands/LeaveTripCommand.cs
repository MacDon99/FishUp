using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Messages.Commands
{
    public record LeaveTripCommand(Guid UserId, Guid TripId) : ICommand;
}
