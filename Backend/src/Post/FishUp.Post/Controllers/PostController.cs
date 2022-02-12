using FishUp.Domain.Types;
using FishUp.Post.Models.Messages.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FishUp.Post.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController : BaseController
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePostCommand(CreatePostCommand command)
            => Ok(await _mediator.Send(command with { AuthorId = UserId }));

        [HttpGet("")]
        public IActionResult GetRecentPosts()
        {
            return Ok();
        }
        
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

        [HttpDelete("{id}/delete")]
        public IActionResult DeletePost(int id)
        {
            return Ok();
        }
    }
}