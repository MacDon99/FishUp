using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Profile.Models;
using FishUp.Profile.Models.Messages.Queries;
using FishUp.Profile.Models.Responses.Queries;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Profile.Handlers.Queries
{
    public class GetProfileDetailsQueryHandler : IQueryHandler<GetProfileDetailsQuery, ProfileDetails>
    {
        private readonly ProfileDbContext _appDbContext;
        public GetProfileDetailsQueryHandler(ProfileDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ProfileDetails> Handle(GetProfileDetailsQuery request, CancellationToken cancellationToken)
        {
            var userDetails = await _appDbContext.Profiles
                .Join(_appDbContext.Users, profile => profile.UserId, user => user.IdentityUserId,
                (profile, user) => new
                {
                    Profile = profile,
                    User = user,
                })
                .Where(group => group.User.IdentityUserId == request.UserId)
                .Select(group => new ProfileDetails()
                {
                    FullName = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName,
                    City = group.Profile.City,
                    Profession = group.Profile.Profession,
                    Voivodeship = group.Profile.Voivodeship,
                    WillToTravelFar = group.Profile.WillToTravelFar,
                    BirthYear = group.Profile.BirthDate.Year
                }).FirstOrDefaultAsync();

            if (userDetails is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Could not find user with given Id");
            }

            return userDetails;
        }
    }
}
