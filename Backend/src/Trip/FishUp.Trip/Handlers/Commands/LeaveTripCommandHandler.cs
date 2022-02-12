using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Commands
{
    public class LeaveTripCommandHandler : ICommandHandler<LeaveTripCommand>
    {
        private readonly TripDbContext _appDbContext;
        public LeaveTripCommandHandler(TripDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(LeaveTripCommand request, CancellationToken cancellationToken)
        {
            var participant = await _appDbContext.Trips
                .Where(trip => trip.Id == request.TripId)
                .SelectMany(trip => trip.Participants)
                .Where(participant => participant.UserId == request.UserId)
                .FirstOrDefaultAsync();

            if (participant is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find trip participant for current user with given user trip id");
            }

            _appDbContext.Participants.Remove(participant);

            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
