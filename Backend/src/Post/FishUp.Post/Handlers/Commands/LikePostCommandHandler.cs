using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Post.Handlers.Commands
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
            var post = await _dbContext.Posts.Include(post => post.Likers).SingleAsync(post => post.Id == request.PostId);
            post.AddLike(request.UserId);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
