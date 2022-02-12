using FishUp.Services.Abstract;
using FishUp.Weather.Models.Responses.Queries;
using FishUp.Weather.Services.Abstract;

namespace FishUp.Weather.Services
{
    public class LocationService : ILocationService
    {
        private readonly IConfigurationRoot _configuration;
        private readonly IHttpClientService _httpClientService;
        public LocationService(IConfigurationRoot configuration, IHttpClientService httpClientService)
        {
            _configuration = configuration;
            _httpClientService = httpClientService;
        }

        public async Task<Location> GetLocationByCityAsync(string city)
        {
            var getCityLocationRequestUrl = _configuration["WeatherForecast:CityLocationUrl"]
                .Replace("{CITY}", city)
                .Replace("{API_KEY}", _configuration["WeatherForecast:API_KEY"]);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, getCityLocationRequestUrl);

            return await _httpClientService.GetAsync<Location>(httpRequest);
        }
        
        public async Task<CurrentLocation> GetLocationByIPAsync(string ip)
        {
            var getCurrentLocationByIP = _configuration["LocationAPI:CurrentLocationDataUrl"]
                .Replace("{IP}", ip)
                .Replace("{API_KEY}", _configuration["LocationAPI:API_KEY"]);
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, getCurrentLocationByIP);

            return await _httpClientService.GetAsync<CurrentLocation>(httpRequest);
        }
    }
}
