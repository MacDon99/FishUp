using FishUp.Domain.Types;
using FishUp.Weather.Models.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishUp.Trip.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : BaseController
    {
        private readonly IMediator _mediator;

        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather(GetCurrentWeatherQuery request)
            => Ok(await _mediator.Send(request));

        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyWeather(GetDailyWeatherQuery request)
            => Ok(await _mediator.Send(request));

        [HttpGet("current-location")]
        public async Task<IActionResult> GetCurrentLocationWeather()
            => Ok(await _mediator.Send(new GetCurrentLocationWeatherQuery(GetIP())));
    }
}