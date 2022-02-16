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
        public async Task<IActionResult> GetRecentPosts()
            => Ok(await _mediator.Send(new GetRecentPostsQuery()));

        [HttpGet("created/{userId}")]
        public async Task<IActionResult> GetCreatedPosts(Guid userId)
            => Ok(await _mediator.Send(new GetCreatedPostsQuery(userId)));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostDetails(Guid id)
            => Ok(await _mediator.Send(new GetPostDetailsQuery(id)));
        
        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostCommand request, Guid id)
            => Ok(await _mediator.Send(request with { UserId = GetUserId(), PostId = id }));

        [HttpPut("{id}/comment")]
        public async Task<IActionResult> CommentPost([FromBody] CommentPostCommand request, Guid id)
            => Ok(await _mediator.Send(request with { UserId = GetUserId(), PostId = id }));

        [HttpPut("{id}/like")]
        public async Task<IActionResult> LikePost(Guid id)
            => Ok(await _mediator.Send(new LikePostCommand(GetUserId(), id)));

        [HttpPut("{id}/unlike")]
        public async Task<IActionResult> UnlikePost(Guid id)
            => Ok(await _mediator.Send(new UnlikePostCommand(GetUserId(), id)));

        [HttpPut("{id}/disLike")]
        public async Task<IActionResult> DislikePost(Guid id)
            => Ok(await _mediator.Send(new DislikePostCommand(GetUserId(), id)));


        [HttpPut("{id}/undisLike")]
        public async Task<IActionResult> UndislikePost(Guid id)
            => Ok(await _mediator.Send(new UndislikePostCommand(GetUserId(), id)));

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeletePost(Guid id)
            => Ok(await _mediator.Send(new DeletePostCommand(GetUserId(), id)));
    }
}