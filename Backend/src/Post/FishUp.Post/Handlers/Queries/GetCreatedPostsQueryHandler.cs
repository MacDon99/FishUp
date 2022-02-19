using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Queries;
using FishUp.Post.Models.Responses.Queries;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Post.Handlers.Queries
{
    public class GetCreatedPostsQueryHandler : IQueryHandler<GetCreatedPostsQuery, CreatedPosts>
    {
        private readonly PostDbContext _dbContext;
        public GetCreatedPostsQueryHandler(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreatedPosts> Handle(GetCreatedPostsQuery request, CancellationToken cancellationToken)
            => new CreatedPosts()
            {
                Posts = await _dbContext.Posts
                  .Where(post => post.Active)
                  .Where(post => post.AuthorId == request.UserId)
                  .Join(_dbContext.Users, post => post.AuthorId, user => user.IdentityUserId, (post, user) => new
                  {
                      Post = post,
                      User = user
                  })
                  .Select(group => new CreatedPost()
                  {
                      Id = group.Post.Id,
                      Author = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName,
                      Content = group.Post.Content,
                      LikesCount = group.Post.LikesCount,
                      DislikesCount = group.Post.DislikesCount,
                      Photos = null
                  }).ToListAsync()
            };
    }
}
