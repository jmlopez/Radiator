using System.Net;
using Radiator.Core.Services.Settings;

namespace Radiator.Core.Services
{
    public class HttpService : IHttpService
    {
        private readonly UrlSettings _settings;

        public HttpService(UrlSettings settings)
        {
            _settings = settings;
        }

        public string DownloadString(string url)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                client.Credentials = new NetworkCredential(_settings.Username, _settings.Password);
                return client.DownloadString(url);
            }
        }
    }
}