using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Models.Types;
using FishUp.Post.Models;
using FishUp.Trip.Models.Messages.Queries;
using FishUp.Trip.Models.Responses.Queries;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Queries
{
    public class GetTripDetailsQueryHandler : IQueryHandler<GetTripDetailsQuery, TripDetails>
    {
        private readonly TripDbContext _appDbContext;
        public GetTripDetailsQueryHandler(TripDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TripDetails> Handle(GetTripDetailsQuery request, CancellationToken cancellationToken)
        {
            var trip = await _appDbContext.Trips
                .Include(trip => trip.Participants)
                .Where(trip => trip.Id == request.TripId)
                .Join(_appDbContext.Users, trip => trip.AuthorId, user => user.IdentityUserId, (trip, user) => new
                 {
                     Trip = trip,
                     User = user
                 })
                .Select(group => new TripDetails()
                {
                    Id = group.Trip.Id,
                    AuthorId = group.Trip.AuthorId,
                    AuthorName = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName,
                    Closed = group.Trip.Closed,
                    Destination = group.Trip.Destination,
                    StartDate = group.Trip.StartDate,
                    EndDate = group.Trip.EndDate,
                    Participants = _appDbContext.Participants
                            .Where(participant => participant.TripId == group.Trip.Id)
                            .Join(_appDbContext.Users, participant => participant.UserId, user => user.IdentityUserId, (participant, user) => new
                            {
                                Participant = participant,
                                User = user
                            }).Select(group => new JoinedParticipant()
                            {
                                Name = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName,
                                ParticipantUserId = group.User.IdentityUserId
                            }).ToList(),
                    Comments = _appDbContext.Comments
                            .Where(comment => comment.TripId == group.Trip.Id)
                            .Join(_appDbContext.Users, comment => comment.AuthorId, user => user.IdentityUserId, (comment, user) => new
                            {
                                Comment = comment,
                                User = user
                            }).Select(group => new AddedComment()
                            {
                                AuthorName = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName,
                                AuthorId = group.Comment.AuthorId,
                                Id = group.Comment.Id,
                                Message = group.Comment.Message
                            }).ToList()
                })
                .FirstOrDefaultAsync();

            if (trip is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find trip with given id");
            }

            return trip;
        }
    }
}
