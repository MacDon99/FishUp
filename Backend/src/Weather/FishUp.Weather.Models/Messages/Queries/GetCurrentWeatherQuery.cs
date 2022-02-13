using FishUp.Dispatchers;
using FishUp.Weather.Models.Responses.Queries;

namespace FishUp.Weather.Models.Messages.Queries
{
    public record GetCurrentWeatherQuery(string City) : IQuery<CurrentWeather>;
}
