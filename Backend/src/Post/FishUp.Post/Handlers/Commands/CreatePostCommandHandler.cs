using FishUp.Dispatchers;
using FishUp.Models.Types;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Commands;
using MediatR;
using PostEntity = FishUp.Post.Models.Entities.Post;

namespace FishUp.Post.Handlers.Commands
{
    public class CreatePostCommandHandler : ICommandHandler<CreatePostCommand>
    {
        private readonly PostDbContext _dbContext;
        public CreatePostCommandHandler(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<StoredFile> photos = null;

            var post = new PostEntity(request.Message, request.AuthorId, photos);
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
