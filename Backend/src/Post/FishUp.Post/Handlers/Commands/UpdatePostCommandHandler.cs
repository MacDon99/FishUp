using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Models.Types;
using FishUp.Post.Models;
using FishUp.Post.Models.Messages.Commands;
using MediatR;

namespace FishUp.Post.Handlers.Commands
{
    public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand>
    {
        private readonly PostDbContext _appDbContext;

        public UpdatePostCommandHandler(PostDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _appDbContext.Posts.FirstOrDefault(post => post.AuthorId == request.UserId && post.Id == request.PostId);
            if (post is null)
            {
                throw new EntityNotFoundException(ExceptionCode.NotExists, "Cannot find post with given Id for current user");
            }

            List<StoredFile> photos = null;

            post.Update(request.Message, photos);

            return Unit.Value;
        }
    }
}
