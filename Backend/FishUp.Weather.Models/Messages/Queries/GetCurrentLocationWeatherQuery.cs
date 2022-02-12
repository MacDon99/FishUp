using FishUp.Dispatchers;
using FishUp.Weather.Models.Responses.Queries;

namespace FishUp.Weather.Models.Messages.Queries
{
    public record GetCurrentLocationWeatherQuery(string IP) : IQuery<CurrentLocationWeather>;
}
