using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Services.Abstract;
using FishUp.Trip.Models.Messages.Queries;
using FishUp.Trip.Models.Responses.Queries;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Trip.Handlers.Queries
{
    public class GetCreatedTripsQueryHandler : IQueryHandler<GetCreatedTripsQuery, CreatedTrips>
    {
        private readonly TripDbContext _appDbContext;
        private readonly IDateTimeProvider _dateTimeProvider;
        public GetCreatedTripsQueryHandler(TripDbContext appDbContext, IDateTimeProvider dateTimeProvider)
        {
            _appDbContext = appDbContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<CreatedTrips> Handle(GetCreatedTripsQuery request, CancellationToken cancellationToken)
            => new()
            {
                Trips = await _appDbContext.Trips
                    .Include(trip => trip.Participants)
                    .Where(trip => trip.AuthorId == request.UserId)
                    .Where(trip => trip.Active)
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
                        Destination = group.Trip.Destination,
                        ParticipantsCount = group.Trip.Participants.Count()
                    }).ToListAsync()
            };
    }
}
