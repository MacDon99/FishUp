using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Queries;
using FishUp.Post.Models.Responses.Queries;

namespace FishUp.Post.Handlers.Queries
{
    public class GetPostDetailsQueryHandler : IQueryHandler<GetPostDetailsQuery, PostDetails>
    {
        private readonly PostDbContext _appDbContext;
        public GetPostDetailsQueryHandler(PostDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PostDetails> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
        {
            var post = _appDbContext.Posts.Join(_appDbContext.Users, post => post.AuthorId, user => user.IdentityUserId, (post, user) => new
            {
                Post = post,
                User = user
            }).Where(group => group.Post.Id == request.PostId).Select(group => new PostDetails()
            { 
                Author = group.User.FirstName + (group.User.SecondName != null ? " " + group.User.SecondName : string.Empty) + " " + group.User.LastName,
                Content = group.Post.Content,
                CreatedDate = group.Post.CreateDate,
                Photos = null,
            }).FirstOrDefault();

            if (post is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find post with given Id");
            }

            return post;
        }
    }
}
