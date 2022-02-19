using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Messages.Commands
{
    public record UndislikeTripCommand(Guid UserId, Guid TripId) : ICommand;
}
