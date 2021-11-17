using System;
using System.Threading;
using System.Threading.Tasks;
using FishUp.Common.Dispatchers;
using FishUp.Identity.Infrastructure;
using FishUp.Identity.Messages.Commands;
using MediatR;

namespace FishUp.Identity.Handlers
{
    public class CreateUserRequestHandler : ICommandHandler<CreateUserRequest>
    {
        private readonly IIdentityUserService _identityUserService;

        public CreateUserRequestHandler(IIdentityUserService identityUserService)
        {
            _identityUserService = identityUserService;
        }

        public Task<Unit> Handle(CreateUserRequest request, CancellationToken cancellationToken)
            => _identityUserService.CreateUserAsync(request, cancellationToken);
    }
}