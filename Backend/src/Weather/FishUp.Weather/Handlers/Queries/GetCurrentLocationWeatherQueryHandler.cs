using FishUp.Dispatchers;
using FishUp.Services.Abstract;
using FishUp.Weather.Models.Messages.Queries;
using FishUp.Weather.Models.Responses.Queries;
using FishUp.Weather.Services.Abstract;

namespace FishUp.Weather.Handlers.Queries
{
    public class GetCurrentLocationWeatherQueryHandler : IQueryHandler<GetCurrentLocationWeatherQuery, CurrentLocationWeather>
    {
        private readonly ILocationService _locationService;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientService _httpClientService;
        public GetCurrentLocationWeatherQueryHandler(ILocationService locationService, IConfiguration configuration,
            IHttpClientService httpClientService)
        {
            _locationService = locationService;
            _configuration = configuration;
            _httpClientService = httpClientService;
        }

        public async Task<CurrentLocationWeather> Handle(GetCurrentLocationWeatherQuery request, CancellationToken cancellationToken)
        {
            var currentLocation = await _locationService.GetLocationByIPAsync(request.IP);
            var getCurrentLocationWeatherUrl = _configuration["WeatherForecast:CurrentWeatherUrl"]
                .Replace("{LAT}", currentLocation.Latitude)
                .Replace("{LON}", currentLocation.Longitude)
                .Replace("{API_KEY}", _configuration["WeatherForecast:API_KEY"]);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, getCurrentLocationWeatherUrl);

            return await _httpClientService.GetAsync<CurrentLocationWeather>(httpRequest);
        }
    }
}
