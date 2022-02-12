using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Commands
{
    public class DeleteTripCommandHandler : ICommandHandler<DeleteTripCommand>
    {
        private readonly TripDbContext _appDbContext;
        public DeleteTripCommandHandler(TripDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(DeleteTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _appDbContext.Trips.FirstOrDefaultAsync(trip => trip.AuthorId == request.UserId && trip.Id == request.TripId);

            if (trip is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find trip for current user with given user id");
            }

            trip.Deactivate();
            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
