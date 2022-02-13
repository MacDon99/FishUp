using FishUp.Dispatchers;
using FishUp.Profile.Models;
using FishUp.Profile.Models.Messages.Queries;
using FishUp.Profile.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Profile.Handlers.Queries
{
    public class GetFriendsQueryHandler : IQueryHandler<GetFriendsQuery, Friendships>
    {
        private readonly ProfileDbContext _appDbContext;
        public GetFriendsQueryHandler(ProfileDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Friendships> Handle(GetFriendsQuery request, CancellationToken cancellationToken)
            => new ()
            {
                UserFriends = await _appDbContext.Friends
                    .Where(friendship => friendship.UserId == request.UserId)
                    .Join(_appDbContext.Users, friendship => friendship.UserId, user => user.IdentityUserId,
                        (friendship, user) => new
                        {
                            Friendship = friendship,
                            User = user
                        })
                        .Select(group => new UserFriend()
                        {
                            UserId = group.Friendship.FriendId,
                            Name = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName
                        }).ToListAsync()
            };
    }
}
