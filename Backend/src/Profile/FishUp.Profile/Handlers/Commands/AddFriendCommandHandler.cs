using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Profile.Models;
using FishUp.Profile.Models.Entities;
using FishUp.Profile.Models.Messages.Commands;
using MediatR;
using System.Transactions;

namespace FishUp.Profile.Handlers.Commands
{
    public class AddFriendCommandHandler : ICommandHandler<AddFriendCommand>
    {
        private readonly ProfileDbContext _dbContext;
        public AddFriendCommandHandler(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddFriendCommand request, CancellationToken cancellationToken)
        {
            var friendship = _dbContext.Friends
                .FirstOrDefault(friend => friend.UserId == request.UserId && friend.FriendId == request.FriendId);

            if (friendship is not null)
            {
                throw new CannotExistException(ExceptionCode.Exists, "Friendship already exists");
            }

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var friend1 = new Friend(request.UserId, request.FriendId);
            var friend2 = new Friend(request.FriendId, request.UserId);

            await _dbContext.Friends.AddAsync(friend1);
            await _dbContext.Friends.AddAsync(friend2);

            await _dbContext.SaveChangesAsync();

            transaction.Complete();

            return Unit.Value;
        }
    }
}
