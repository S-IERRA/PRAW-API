using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using BenchmarkDotNet.Attributes;

namespace PRAW.Handlers
{
    internal class HTTPHandlers
    {
        private static StringContent HttpContent(string Data) =>
            new(Data, Encoding.UTF8, "application/json");

        private HttpClient httpClient { get; } = new HttpClient().Modify(client =>
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(User.Token));

        internal async Task<HttpResponseMessage> PostAsync(string URI, string Data) =>
             await httpClient.PostAsync(URI, HttpContent(Data));

        internal async Task<HttpResponseMessage> PatchAsync(string URI, string Data) =>
             await httpClient.PatchAsync(URI, HttpContent(Data));

        internal async Task<string> GetAsync(string URI) =>
             await httpClient.GetStringAsync(URI);
    }
}
