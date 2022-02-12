using FishUp.Dispatchers;
using FishUp.Post.Models.Messages.Commands;
using MediatR;

namespace FishUp.Post.Handlers
{
    public class CreatePostCommandHandler : ICommandHandler<CreatePostCommand>
    {
        public Task<Unit> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
