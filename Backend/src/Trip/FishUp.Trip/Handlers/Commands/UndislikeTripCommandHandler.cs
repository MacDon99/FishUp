using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Commands
{
    public class UndislikeTripCommandHandler : ICommandHandler<UndislikeTripCommand>
    {
        private readonly TripDbContext _dbContext;

        public UndislikeTripCommandHandler(TripDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UndislikeTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _dbContext.Trips.Include(trip => trip.Dislikers).SingleAsync(post => post.Id == request.TripId);
            trip.RemoveDislike(request.UserId);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
