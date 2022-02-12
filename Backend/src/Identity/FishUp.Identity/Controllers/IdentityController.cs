using System.Threading;
using System.Threading.Tasks;
using FishUp.Identity.Infrastructure;
using FishUp.Identity.Messages.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FishUp.Identity.Controllers
{
    [ApiController]
    [Route("/identity")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityUserService _identityUserService;
        private readonly IMediator _mediator;

        public IdentityController(IIdentityUserService identityUserService, IMediator mediator)
        {
            _identityUserService  = identityUserService;
            _mediator = mediator;
        }

        [Route("sign-up")]
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(request));

        [Route("sign-in")]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request, CancellationToken cancellationToken)
            => Ok(await _identityUserService.SignInAsync(request, cancellationToken));

    }
}