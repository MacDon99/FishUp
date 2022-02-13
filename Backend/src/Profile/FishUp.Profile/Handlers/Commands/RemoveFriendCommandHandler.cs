using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Profile.Models;
using FishUp.Profile.Models.Messages.Commands;
using MediatR;
using System.Transactions;

namespace FishUp.Profile.Handlers.Commands
{
    public class RemoveFriendCommandHandler : ICommandHandler<RemoveFriendCommand>
    {
        private readonly ProfileDbContext _dbContext;
        public RemoveFriendCommandHandler(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(RemoveFriendCommand request, CancellationToken cancellationToken)
        {
            var friendship1 = _dbContext.Friends
                .FirstOrDefault(friend => friend.UserId == request.UserId && friend.FriendId == request.FriendId);

            var friendship2 = _dbContext.Friends
                .FirstOrDefault(friend => friend.UserId == request.FriendId && friend.FriendId == request.UserId);

            if (friendship1 is null && friendship2 is null)
            {
                throw new EntityNotFoundException(ExceptionCode.Exists, "Friendship cannot be found");
            }
            else if (friendship1 is null && friendship2 is not null || friendship1 is not null && friendship2 is null)
            { 
                throw new ServerException(ExceptionCode.InvalidValue, "Half of entity relation exists");
            }

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            _dbContext.Friends.Remove(friendship1);
            _dbContext.Friends.Remove(friendship2);

            await _dbContext.SaveChangesAsync();

            transaction.Complete();

            return Unit.Value;
        }
    }
}
