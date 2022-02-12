using FishUp.Domain.Types;
using FishUp.Post.Models.Messages.Commands;
using FishUp.Post.Models.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishUp.Post.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/post")]
    public class PostController : BaseController
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostCommand(CreatePostCommand command)
            => Ok(await _mediator.Send(command with { AuthorId = GetUserId() }));

        [HttpGet]
        public IActionResult GetRecentPosts()
        {
            return Ok();
        }

        [HttpGet("created")]
        public async Task<IActionResult> GetCreatedPosts()
            => Ok(await _mediator.Send(new GetCreatedPostsQuery(GetUserId())));

        [HttpGet("{id}")]
        public IActionResult GetPostDetails(int id)
        {
            return Ok();
        }
        
        [HttpPut("{id}/update")]
        public IActionResult UpdatePost(int id)
        {
            return Ok();
        }

        [HttpPut("{id}/like")]
        public async Task<IActionResult> LikePost(Guid id)
            => Ok(await _mediator.Send(new LikePostCommand(GetUserId(), id)));

        [HttpPut("{id}/unlike")]
        public async Task<IActionResult> UnlikePost(Guid id)
            => Ok(await _mediator.Send(new UnlikePostCommand(GetUserId(), id)));

        [HttpPut("{id}/disLike")]
        public IActionResult DisLike(int id)
        {
            return Ok();
        }

        [HttpPut("{id}/undisLike")]
        public IActionResult UndisLike(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}/delete")]
        public IActionResult DeletePost(int id)
        {
            return Ok();
        }
    }
}