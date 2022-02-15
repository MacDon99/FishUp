using FishUp.Domain.Types;
using FishUp.Profile.Models.Messages.Commands;
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

        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody] CreateProfileCommand request)
            => Ok(await _mediator.Send(request with { UserId = GetUserId() }));


        [HttpGet]
        public async Task<IActionResult> GetProfileDetails([FromQuery] GetProfileDetailsQuery request)
            => Ok(await _mediator.Send(request with { UserId = GetUserId() }));

        [HttpGet("search")]
        public async Task<IActionResult> GetProfileForSearcher([FromQuery] GetProfileForSearcherQuery request)
            => Ok(await _mediator.Send(request));
    }
}
