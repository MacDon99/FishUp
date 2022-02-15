using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Profile.Models;
using FishUp.Profile.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProfileEntity = FishUp.Profile.Models.Entities.Profile;

namespace FishUp.Profile.Handlers.Commands
{
    public class CreateProfileCommandHandler : ICommandHandler<CreateProfileCommand>
    {
        private readonly ProfileDbContext _dbContext;
        public CreateProfileCommandHandler(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _dbContext.Users.AnyAsync(user => user.IdentityUserId == request.UserId);

            if (!userExist)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find user with given id");
            }

            var profileExist = await _dbContext.Profiles.AnyAsync(profile => profile.UserId == request.UserId);

            if (profileExist)
            {
                throw new CannotExistException(ExceptionCode.Exists, "Profile for given user already exist");
            }

            var profile = new ProfileEntity(request.UserId, request.City, request.Voivodeship, request.BirthDate, request.Profession, request.WillToTravelFar);
            await _dbContext.Profiles.AddAsync(profile);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
