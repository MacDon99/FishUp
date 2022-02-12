using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Commands;
using MediatR;
using TripEntity = FishUp.Trip.Models.Entities.Trip;

namespace FishUp.Trip.Handlers.Commands
{
    public class CreateTripCommandHandler : ICommandHandler<CreateTripCommand>
    {
        private readonly TripDbContext _dbContext;
        public CreateTripCommandHandler(TripDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateTripCommand request, CancellationToken cancellationToken)
        {
            var trip = new TripEntity(request.Destination, request.StartDate, request.EndDate, request.AuthorId);
            await _dbContext.Trips.AddAsync(trip);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
