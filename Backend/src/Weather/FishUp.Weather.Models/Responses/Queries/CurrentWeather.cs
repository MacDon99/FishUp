using FishUp.Dispatchers;

namespace FishUp.Weather.Models.Responses.Queries
{
    public class CurrentWeather : IQueryResponse
    {
        public Main Main { get; set; }

        public long Visibility { get; set; }

        public Wind Wind { get; set; }
    }

    public partial class Main
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public long Pressure { get; set; }
        public long Humidity { get; set; }
    }

    public partial class Wind
    {
        public double Speed { get; set; }
    }
}