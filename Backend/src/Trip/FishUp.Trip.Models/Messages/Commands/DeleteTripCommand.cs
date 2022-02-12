using FishUp.Dispatchers;

namespace FishUp.Trip.Models.Messages.Commands
{
    public record DeleteTripCommand(Guid UserId, Guid TripId) : ICommand;
}
