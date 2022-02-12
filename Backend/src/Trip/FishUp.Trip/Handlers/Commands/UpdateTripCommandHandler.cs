using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Commands
{
    public class UpdateTripCommandHandler : ICommandHandler<UpdateTripCommand>
    {
        private readonly TripDbContext _appDbContext;
        public UpdateTripCommandHandler(TripDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _appDbContext.Trips.FirstOrDefaultAsync(trip => trip.AuthorId == request.UserId && trip.Id == request.TripId);

            if (trip is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find trip for current user with given user id");
            }

            trip.Update(request.Destination, request.StartDate, request.EndDate, request.Closed);

            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
