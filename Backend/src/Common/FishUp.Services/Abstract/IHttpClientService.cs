namespace FishUp.Services.Abstract
{
    public interface IHttpClientService
    {
        Task<T> GetAsync<T>(HttpRequestMessage request);
    }
}
