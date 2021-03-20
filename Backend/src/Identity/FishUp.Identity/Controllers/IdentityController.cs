using System.Threading;
using System.Threading.Tasks;
using FishUp.Identity.Infrastructure;
using FishUp.Identity.Messages.Commands;
using Microsoft.AspNetCore.Mvc;

namespace FishUp.Identity.Controllers
{
    [ApiController]
    [Route("/identity")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityUserService _identityUserService;
        public IdentityController(IIdentityUserService identityUserService)
        {
            _identityUserService  = identityUserService;
        }
        [Route("sign-up")]
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            
            return Ok(await _identityUserService.CreateUserAsync(request, cancellationToken));
        }
    }
}