using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Services.Abstract;
using FishUp.Trip.Models.Messages.Queries;
using FishUp.Trip.Models.Responses.Queries;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Queries
{
    public class GetAvailableTripsQueryHandler : IQueryHandler<GetAvailableTripsQuery, AvailableTrips>
    {
        private readonly TripDbContext _appDbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        public GetAvailableTripsQueryHandler(TripDbContext appDbContext, IDateTimeProvider dateTimeProvider)
        {
            _appDbContext = appDbContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<AvailableTrips> Handle(GetAvailableTripsQuery request, CancellationToken cancellationToken)
            => new()
            {
                Trips = await _appDbContext.Trips
                    .Join(_appDbContext.Users, trip => trip.AuthorId, user => user.IdentityUserId, (trip, user) => new
                    { 
                      Trip = trip,
                      User = user
                    })
                    .Where(group => !group.Trip.Closed && group.Trip.StartDate > _dateTimeProvider.GetCurrentDate())
                    .Select(group => new AvailableTrip()
                    { 
                        Author = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName,
                        Closed = group.Trip.Closed,
                        Destination = group.Trip.Destination,
                        EndDate = group.Trip.EndDate,
                        StartDate = group.Trip.StartDate,
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
                            }).ToList()
                    }).ToListAsync()
            };
    }
}
