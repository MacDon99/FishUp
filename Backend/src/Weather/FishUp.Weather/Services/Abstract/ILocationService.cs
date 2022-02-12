using FishUp.Weather.Models.Responses.Queries;

namespace FishUp.Weather.Services.Abstract
{
    public interface ILocationService
    {
        Task<Location> GetLocationByCityAsync(string city);
        Task<CurrentLocation> GetLocationByIPAsync(string ip);
    }
}
