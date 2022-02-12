using FishUp.Dispatchers;
using FishUp.Services.Abstract;
using FishUp.Weather.Models.Messages.Queries;
using FishUp.Weather.Models.Responses.Queries;
using FishUp.Weather.Services.Abstract;
using Newtonsoft.Json;

namespace FishUp.Weather.Handlers.Queries
{
    public class GetCurrentWeatherQueryHandler : IQueryHandler<GetCurrentWeatherQuery, CurrentWeather>
    {
        private readonly ILocationService _locationService;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientService _httpClientService;
        public GetCurrentWeatherQueryHandler(ILocationService locationService, IConfiguration configuration, 
            IHttpClientService httpClientService)
        {
            _locationService = locationService;
            _configuration = configuration;
            _httpClientService = httpClientService;
        }

        public async Task<CurrentWeather> Handle(GetCurrentWeatherQuery request, CancellationToken cancellationToken)
        {
            var location = await _locationService.GetLocationByCityAsync(request.City);

            var getCurrentWeatherUrl = _configuration["WeatherForecast:CurrentWeatherUrl"]
                .Replace("{LAT}", location.Lat.ToString())
                .Replace("{LON}", location.Lon.ToString())
                .Replace("{API_KEY}", _configuration["WeatherForecast:API_KEY"]);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, getCurrentWeatherUrl);

            return await _httpClientService.GetAsync<CurrentWeather>(httpRequest);
        }
    }
}
