namespace FishUp.Weather.Models.Responses.Queries
{
    public class CurrentLocation
    {
        public string City { get; set; }
        public long Zipcode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
