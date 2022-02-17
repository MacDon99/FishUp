using FishUp.Dispatchers;
using FishUp.Profile.Models.Responses.Queries;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Profile.Models.Messages.Queries
{
    public class GetProfilesForSearcherQueryHandler : IQueryHandler<GetProfilesForSearcherQuery, ProfilesForSearcher>
    {
        private readonly ProfileDbContext _appDbContext;
        public GetProfilesForSearcherQueryHandler(ProfileDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ProfilesForSearcher> Handle(GetProfilesForSearcherQuery request, CancellationToken cancellationToken)
            => new ProfilesForSearcher()
            {
                Profiles = await _appDbContext.Profiles.Join(_appDbContext.Users, profile => profile.UserId, user => user.IdentityUserId,
                (profile, user) => new
                {
                    Profile = profile,
                    User = user,
                }).Where(group => (group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName).Contains(request.SearchPhrase))
                .Select(group => new ProfileForSearcher()
                {
                    UserId = group.Profile.UserId,
                    FullName = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName
                }).ToListAsync()
            };
    }
}
