using FishUp.Dispatchers;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Post.Handlers.Commands
{
    public class DislikePostCommandHandler : ICommandHandler<DislikePostCommand>
    {
        private readonly PostDbContext _dbContext;

        public DislikePostCommandHandler(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DislikePostCommand request, CancellationToken cancellationToken)
        {
            var post = _dbContext.Posts.Include(post => post.Dislikers).Single(post => post.Id == request.PostId);
            post.AddDislike(request.UserId);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
