using FishUp.Dispatchers;

namespace FishUp.Weather.Models.Responses.Queries
{
    public class Weathers : IQueryResponse
    {
        public IEnumerable<CurrentWeather> Forecasts { get; set; }
    }
}
