using FishUp.Domain.Types;
using FishUp.Profile.Models.Messages.Commands;
using FishUp.Profile.Models.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishUp.Post.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/profile/friend")]
    public class FriendController : BaseController
    {
        private readonly IMediator _mediator;

        public FriendController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFriend([FromBody]AddFriendCommand request)
            => Ok(await _mediator.Send(request with { UserId = GetUserId() }));

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFriend([FromBody]RemoveFriendCommand request)
            => Ok(await _mediator.Send(request with { UserId = GetUserId() }));

        [HttpGet]
        public async Task<IActionResult> GetFriends([FromQuery]GetFriendsQuery request)
            => Ok(await _mediator.Send(request with { UserId = GetUserId() }));
    }
}