using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Queries;
using FishUp.Post.Models.Responses.Queries;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Post.Handlers.Queries
{
    public class GetRecentPostsQueryHandler : IQueryHandler<GetRecentPostsQuery, RecentPosts>
    {
        private readonly PostDbContext _appDbContext;
        public GetRecentPostsQueryHandler(PostDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<RecentPosts> Handle(GetRecentPostsQuery request, CancellationToken cancellationToken)
            => new()
            {
                Posts = await _appDbContext.Posts
                    .Join(_appDbContext.Friends, post => post.AuthorId, friend => friend.UserId, (post, friend) => new
                    {
                        Post = post,
                        Friend = friend
                    })
                    .Where(group => group.Friend.UserId != request.UserId)
                    .Where(group => group.Friend.FriendId == request.UserId)
                    .Join(_appDbContext.Users, group => group.Friend.UserId, user => user.IdentityUserId, (postFriendsGroup, user) => new
                    {
                        PostFriendsGroup = postFriendsGroup,
                        User = user
                    })
                    .Select(group => new RecentPost()
                    {
                        PostId = group.PostFriendsGroup.Post.Id,
                        Message = group.PostFriendsGroup.Post.Content,
                        AuthorName = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName
                    }).ToListAsync()
            };
    }
}
