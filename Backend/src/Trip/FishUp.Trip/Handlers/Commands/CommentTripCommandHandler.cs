using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Commands
{
    public class CommentTripCommandHandler : ICommandHandler<CommentTripCommand>
    {
        private readonly TripDbContext _appDbContext;
        public CommentTripCommandHandler(TripDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(CommentTripCommand request, CancellationToken cancellationToken)
        {
            var trip = await _appDbContext.Trips.FirstOrDefaultAsync(trip => trip.Id == request.TripId);

            if (trip is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find trip with given user id");
            }

            trip.Comment(request.UserId, request.Message);
            try
            {

            await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }

            return Unit.Value;
        }
    }
}
