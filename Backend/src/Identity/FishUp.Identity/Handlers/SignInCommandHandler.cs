using FishUp.Dispatchers;
using FishUp.Identity.Infrastructure;
using FishUp.Identity.Messages.Commands;
using FishUp.Identity.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace FishUp.Identity.Handlers
{
    public class SignInCommandHandler : ICommandHandler<SignInCommand, SignInResponse>
    {
        private readonly IIdentityUserService _identityUserService;
        public SignInCommandHandler(IIdentityUserService identityUserService)
        {
            _identityUserService = identityUserService;
        }

        public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
            => await _identityUserService.SignInAsync(request, cancellationToken);
    }
}
