using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Post.Handlers.Commands
{
    public class UndislikePostCommandHandler : ICommandHandler<UndislikePostCommand>
    {
        private readonly PostDbContext _dbContext;

        public UndislikePostCommandHandler(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UndislikePostCommand request, CancellationToken cancellationToken)
        {
            var post = _dbContext.Posts.Include(post => post.Dislikers).Single(post => post.Id == request.PostId);
            post.RemoveDislike(request.UserId);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
