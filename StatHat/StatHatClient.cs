using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StatHat
{
    public interface IStatHatClient 
    {
        Task CountAsync(string stat, int count);
        Task CountAsync(string stat, double count);
        Task ValueAsync(string stat, int value);
        Task ValueAsync(string stat, double value);
    }

    public sealed class StatHatClient : IStatHatClient
    {
        private const string _statHatUri = "https://api.stathat.com/ez";
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiKey;
        public StatHatClient(string apiKey)
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public Task CountAsync(string stat, int count)
        {
            return CountAsync(stat, (double) count);
        }

        public Task CountAsync(string stat, double count)
        {
            return PostToStatHat(stat, count);
        }

        public Task ValueAsync(string stat, int value)
        {
            return ValueAsync(stat, (double) value);
        }

        public Task ValueAsync(string stat, double value)
        {
            return PostToStatHat(stat, value);
        }
        
        // TODO: Would be great to be able to pass in a collection of stats
        // public Task CountAsync(params EZStat[] stats) 
        // {

            
        // }

        private Task PostToStatHat(string stat, double count) {
            var ezRequest = new EZRequest(_apiKey, new EZStat(stat, count));
            var content = new StringContent(ezRequest.ToString(), Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, _statHatUri) {
                Content = content
            };

            request.Content.Headers.ContentType.CharSet = null;
            
            _httpClient.SendAsync(request).ConfigureAwait(false);

            return Task.CompletedTask;
        }
    }
}
