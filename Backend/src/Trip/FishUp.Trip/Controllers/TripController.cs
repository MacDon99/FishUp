using FishUp.Domain.Types;
using FishUp.Trip.Models.Messages.Commands;
using FishUp.Trip.Models.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishUp.Trip.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/trip")]
    public class TripController : BaseController
    {
        private readonly IMediator _mediator;

        public TripController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrip(CreateTripCommand request)
            => Ok(await _mediator.Send(request with { AuthorId = GetUserId() }));

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableTrips()
            => Ok(await _mediator.Send(new GetAvailableTripsQuery(GetUserId())));

        [HttpGet("created")]
        public async Task<IActionResult> GetCreatedTrips()
            => Ok(await _mediator.Send(new GetCreatedTripsQuery(GetUserId())));

        [HttpGet("joined")]
        public async Task<IActionResult> GetJoinedTrips()
            => Ok(await _mediator.Send(new GetJoinedTripsQuery(GetUserId())));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripDetails(Guid id)
            => Ok(await _mediator.Send(new GetTripDetailsQuery(id, GetUserId())));

        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateTrip([FromBody] UpdateTripCommand request, Guid id)
            => Ok(await _mediator.Send(request with { UserId = GetUserId(), TripId = id }));

        [HttpPut("{id}/like")]
        public async Task<IActionResult> LikeTrip(Guid id)
            => Ok(await _mediator.Send(new LikeTripCommand(GetUserId(), id)));

        [HttpPut("{id}/unlike")]
        public async Task<IActionResult> UnlikeTrip(Guid id)
            => Ok(await _mediator.Send(new UnlikeTripCommand(GetUserId(), id)));

        [HttpPut("{id}/disLike")]
        public async Task<IActionResult> DislikeTrip(Guid id)
            => Ok(await _mediator.Send(new DislikeTripCommand(GetUserId(), id)));

        [HttpPut("{id}/unDisLike")]
        public async Task<IActionResult> UndislikeTrip(Guid id)
            => Ok(await _mediator.Send(new UndislikeTripCommand(GetUserId(), id)));

        [HttpPut("{id}/comment")]
        public async Task<IActionResult> CommentTrip([FromBody] CommentTripCommand request, Guid id)
            => Ok(await _mediator.Send(request with { UserId = GetUserId(), TripId = id }));

        [HttpPut("{id}/uncomment/{commentId}")]
        public async Task<IActionResult> UnCommentTrip([FromBody] UnCommentTripCommand request, Guid id, Guid commentId)
            => Ok(await _mediator.Send(request with { UserId = GetUserId(), TripId = id, CommentId = commentId }));

        [HttpPut("{id}/participate")]
        public async Task<IActionResult> ParticipateTrip([FromBody] ParticipateTripCommand request, Guid id)
            => Ok(await _mediator.Send(request with { UserId = GetUserId(), TripId = id }));

        [HttpPut("{id}/leave")]
        public async Task<IActionResult> LeaveTrip([FromBody] LeaveTripCommand request, Guid id)
            => Ok(await _mediator.Send(request with { UserId = GetUserId(), TripId = id }));

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteTrip(Guid id)
            => Ok(await _mediator.Send(new DeleteTripCommand(GetUserId(), id)));
    }
}