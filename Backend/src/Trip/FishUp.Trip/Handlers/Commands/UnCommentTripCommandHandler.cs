using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Commands
{
    public class UnCommentTripCommandHandler : ICommandHandler<UnCommentTripCommand>
    {
        private readonly TripDbContext _appDbContext;
        public UnCommentTripCommandHandler(TripDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(UnCommentTripCommand request, CancellationToken cancellationToken)
        {
            var comment = await _appDbContext.Trips
                .Where(trip => trip.Id == request.TripId)
                .SelectMany(trip => trip.Comments)
                .FirstOrDefaultAsync(comment => comment.AuthorId == request.UserId && comment.Id == request.CommentId);

            if (comment is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find comment for current trip and user with given user id");
            }

            comment.Deactivate();
            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
