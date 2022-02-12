using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Commands
{
    public class ParticipateTripCommandHandler : ICommandHandler<ParticipateTripCommand>
    {
        private readonly TripDbContext _appDbContext;
        public ParticipateTripCommandHandler(TripDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(ParticipateTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _appDbContext.Trips.FirstOrDefaultAsync(trip => trip.Id == request.TripId);

            if (trip is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find trip for current user with given user id");
            }

            trip.Participate(request.UserId);
            
            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
