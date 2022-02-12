using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Messages.Commands
{
    public record ParticipateTripCommand(Guid UserId, Guid TripId) : ICommand;
}
