using FishUp.Services.Abstract;
using Newtonsoft.Json;

namespace FishUp.Services
{
    public class HttpClientService : IHttpClientService
    {
        public async Task<T> GetAsync<T>(HttpRequestMessage request)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
