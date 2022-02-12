using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Post.Handlers
{
    public class LikePostCommandHandler : ICommandHandler<LikePostCommand>
    {
        private readonly PostDbContext _dbContext;
        
        public LikePostCommandHandler(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            var post = _dbContext.Posts.Include(post => post.Likers).Single(post => post.Id == request.postId);
            post.AddLike(request.UserId);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
