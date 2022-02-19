using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Commands
{
    public class UnlikeTripCommandHandler : ICommandHandler<UnlikeTripCommand>
    {
        private readonly TripDbContext _dbContext;

        public UnlikeTripCommandHandler(TripDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UnlikeTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _dbContext.Trips.Include(trip => trip.Likers).SingleAsync(trip => trip.Id == request.TripId);
            trip.RemoveLike(request.UserId);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
