using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Models.Types;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FishUp.Post.Handlers.Commands
{
    public class CommentPostCommandHandler : ICommandHandler<CommentPostCommand>
    {
        private readonly PostDbContext _appDbContext;
        public CommentPostCommandHandler(PostDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(CommentPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _appDbContext.Posts.FirstOrDefaultAsync(post => post.Id == request.PostId);
            if (post is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find post with given Id");
            }

            var comment = new Comment(request.UserId, request.Message);

            post.AddComment(comment);

            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
