using FishUp.Domain.Types;
using FishUp.Profile.Models.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishUp.Profile.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : BaseController
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfileDetails(GetProfileDetailsQuery request)
            => Ok(_mediator.Send(request with { UserId = GetUserId() }));
    }
}
