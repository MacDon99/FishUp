using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Services.Abstract;
using FishUp.Trip.Models.Messages.Queries;
using FishUp.Trip.Models.Responses.Queries;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Queries
{
    public class GetJoinedTripsQueryHandler : IQueryHandler<GetJoinedTripsQuery, CreatedTrips>
    {
        private readonly TripDbContext _appDbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        public GetJoinedTripsQueryHandler(TripDbContext appDbContext, IDateTimeProvider dateTimeProvider)
        {
            _appDbContext = appDbContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<CreatedTrips> Handle(GetJoinedTripsQuery request, CancellationToken cancellationToken)
            => new()
            {
                Trips = await _appDbContext.Trips
                    .Include(trip => trip.Participants)
                    .Where(trip => trip.Active)
                    .Where(trip => trip.Participants.FirstOrDefault(participant => participant.UserId == request.UserId) != null)
                    .Join(_appDbContext.Users, trip => trip.AuthorId, user => user.IdentityUserId, (trip, user) => new
                    {
                        Trip = trip,
                        User = user
                    })
                    .Where(group => !group.Trip.Closed && group.Trip.StartDate > _dateTimeProvider.GetCurrentDate())
                    .Select(group => new CreatedTrip()
                    {
                        Id = group.Trip.Id,
                        Author = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName,
                        Destination = group.Trip.Destination
                    }).ToListAsync()
            };
    }
}
