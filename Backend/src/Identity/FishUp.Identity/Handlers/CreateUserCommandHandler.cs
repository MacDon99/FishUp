using System.Threading;
using System.Threading.Tasks;
using FishUp.Dispatchers;
using FishUp.Identity.Infrastructure;
using FishUp.Identity.Messages.Commands;
using FishUp.Identity.Models.Responses;

namespace FishUp.Identity.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, SignUpResponse>
    {
        private readonly IIdentityUserService _identityUserService;

        public CreateUserCommandHandler(IIdentityUserService identityUserService)
        {
            _identityUserService = identityUserService;
        }

        public Task<SignUpResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            => _identityUserService.CreateUserAsync(request, cancellationToken);
    }
}