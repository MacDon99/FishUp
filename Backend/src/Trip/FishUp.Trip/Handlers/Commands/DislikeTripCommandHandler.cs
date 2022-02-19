using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Commands
{
    public class DislikeTripCommandHandler : ICommandHandler<DislikeTripCommand>
    {
        private readonly TripDbContext _dbContext;

        public DislikeTripCommandHandler(TripDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DislikeTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _dbContext.Trips.Include(trip => trip.Dislikers).SingleAsync(post => post.Id == request.TripId);
            trip.AddDislike(request.UserId);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
