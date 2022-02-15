using FishUp.Dispatchers;
using FishUp.Profile.Models;
using FishUp.Profile.Models.Messages.Queries;
using FishUp.Profile.Models.Responses;
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

        public Task<ProfileDetails> Handle(GetProfileDetailsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
