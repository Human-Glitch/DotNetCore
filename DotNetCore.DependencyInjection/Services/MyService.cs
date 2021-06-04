using System.Net.Http;
using DotNetCore.DependencyInjection.Interfaces;

namespace DotNetCore.DependencyInjection.Services
{
    public class MyService : IMyService
    {
        private HttpClient _httpClient;

        public HttpClient Client
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                }

                return _httpClient;
            }
        }

        public MyService()
        {
            
        }

        public string GetResponse(string path)
        {
            return Client.GetAsync(path).Result.ToString();
        }
    }
}