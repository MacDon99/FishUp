using FishUp.Dispatchers;
using FishUp.Domain.Types;
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

        public async Task<ProfileDetails> Handle(GetProfileDetailsQuery request, CancellationToken cancellationToken)
        {
            var userDetails = await _appDbContext.Users
                .Where(user => user.IdentityUserId == request.UserId)
                .Select(user => new ProfileDetails()
                {
                    FullName = user.FirstName + (user.SecondName != null ? " " + user.SecondName : string.Empty) + " " + user.LastName,
                }).FirstOrDefaultAsync();

            if (userDetails is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Could not find user with given Id");
            }

            return userDetails;
        }
    }
}
