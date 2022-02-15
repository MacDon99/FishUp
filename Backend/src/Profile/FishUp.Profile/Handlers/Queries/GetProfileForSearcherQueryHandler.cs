using FishUp.Dispatchers;
using FishUp.Profile.Models.Responses.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishUp.Profile.Models.Messages.Queries
{
    public class GetProfileForSearcherQueryHandler : IQueryHandler<GetProfileForSearcherQuery, ProfileForSearcher>
    {
        private readonly ProfileDbContext _appDbContext;
        public GetProfileForSearcherQueryHandler(ProfileDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ProfileForSearcher> Handle(GetProfileForSearcherQuery request, CancellationToken cancellationToken)
        {
            var profile = await _appDbContext.Profiles.Join(_appDbContext.Users, profile => profile.UserId, user => user.IdentityUserId,
                (profile, user) => new
                {
                    Profile = profile,
                    User = user,
                }).Where(group => (group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName).Contains(request.SearchPhrase))
                .Select(group => new ProfileForSearcher()
                { 
                    FullName = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName
                }).FirstOrDefaultAsync();

            return profile;
        }
    }
}
