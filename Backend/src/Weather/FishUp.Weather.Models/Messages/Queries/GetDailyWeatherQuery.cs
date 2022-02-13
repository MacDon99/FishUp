using FishUp.Dispatchers;
using FishUp.Weather.Models.Responses.Queries;

namespace FishUp.Weather.Models.Messages.Queries
{
    public record GetDailyWeatherQuery(string City, int Days) : IQuery<Weathers>;
}
