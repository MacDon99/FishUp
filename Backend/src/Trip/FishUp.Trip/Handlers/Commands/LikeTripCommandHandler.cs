using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Commands
{
    public class LikeTripCommandHandler : ICommandHandler<LikeTripCommand>
    {
        private readonly TripDbContext _dbContext;

        public LikeTripCommandHandler(TripDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(LikeTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _dbContext.Trips.Include(trip => trip.Likers).SingleAsync(post => post.Id == request.TripId);
            trip.AddLike(request.UserId);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
