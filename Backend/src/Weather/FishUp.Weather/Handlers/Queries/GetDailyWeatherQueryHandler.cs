using FishUp.Dispatchers;
using FishUp.Services.Abstract;
using FishUp.Weather.Models.Messages.Queries;
using FishUp.Weather.Models.Responses.Queries;

namespace FishUp.Weather.Handlers.Queries
{
    public class GetDailyWeatherQueryHandler : IQueryHandler<GetDailyWeatherQuery, Weathers>
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientService _httpClientService;
        public GetDailyWeatherQueryHandler(IConfiguration configuration, IHttpClientService httpClientService)
        {
            _configuration = configuration;
            _httpClientService = httpClientService;
        }

        public async Task<Weathers> Handle(GetDailyWeatherQuery request, CancellationToken cancellationToken)
        {
            var getCurrentWeatherUrl = _configuration["WeatherForecast:DailyWeatherUrl"]
                .Replace("{CITY}", request.City)
                .Replace("{DAYS}", request.Days.ToString())
                .Replace("{API_KEY}", _configuration["WeatherForecast:API_KEY"]);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, getCurrentWeatherUrl);

            return new()
            {
                Forecasts = await _httpClientService.GetAsync<IEnumerable<CurrentWeather>>(httpRequest)
            };
        }
    }
}
