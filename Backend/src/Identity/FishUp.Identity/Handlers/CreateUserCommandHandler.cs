using System.Threading;
using System.Threading.Tasks;
using FishUp.Dispatchers;
using FishUp.Identity.Infrastructure;
using FishUp.Identity.Messages.Commands;
using MediatR;

namespace FishUp.Identity.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IIdentityUserService _identityUserService;

        public CreateUserCommandHandler(IIdentityUserService identityUserService)
        {
            _identityUserService = identityUserService;
        }

        public Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            => _identityUserService.CreateUserAsync(request, cancellationToken);
    }
}