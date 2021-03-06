using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Post.Handlers.Commands
{
    public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
    {
        private readonly PostDbContext _appDbContext;

        public DeletePostCommandHandler(PostDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _appDbContext.Posts.FirstOrDefaultAsync(post => post.AuthorId == request.UserId && post.Id == request.PostId);
            if (post is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find post with given Id for current user");
            }
            post.Deactivate();
            await _appDbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
