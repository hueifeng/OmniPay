using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OmniPay.Core.Utils
{
    public class HttpHandler : IHttpHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public HttpClient CreateHttpClient(string? name = null)
        {
            _ = _httpClientFactory ?? throw new NullReferenceException("No IHttpClientFactory provided, please add AddHttpClient() in configure services!");
            return _httpClientFactory.CreateClient(name);
        }

        public async Task<T> GetAsync<T>(string url, JsonSerializerOptions options = null, params (string, object)[] headers)
        {
            _ = _httpClientFactory ?? throw new NullReferenceException("No IHttpClientFactory provided, please add AddHttpClient() in configure services!");
            var httpClient = _httpClientFactory.CreateClient();

            var streamTask = httpClient.GetStreamAsync(url);

            return await JsonSerializer.DeserializeAsync<T>(await streamTask.ConfigureAwait(false), options);
        }

        public async Task<string> PostAsync(string url, object request, JsonSerializerOptions options = null, params (string, object)[] headers)
        {
            _ = _httpClientFactory ?? throw new NullReferenceException("No IHttpClientFactory provided, please add AddHttpClient() in configure services!");
            var httpClient = _httpClientFactory.CreateClient();

            var bytesToPost = JsonSerializer.SerializeToUtf8Bytes(request, request.GetType(), options);

            var response = await httpClient.PostAsync(url, new ByteArrayContent(bytesToPost));

            response.EnsureSuccessStatusCode();

            var streamTask = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return streamTask;
        }

        public async Task<string> PostAsync(string url, string request, string logicalName, JsonSerializerOptions options = null, params (string, object)[] headers)
        {
            _ = _httpClientFactory ?? throw new NullReferenceException("No IHttpClientFactory provided, please add AddHttpClient() in configure services!");
            HttpClient httpClient;
            if (logicalName == null)
            {
                httpClient = _httpClientFactory.CreateClient();
            }
            else
            {
                httpClient = _httpClientFactory.CreateClient(logicalName);
            }

            var reqContent = new StringContent(request, Encoding.UTF8, "application/x-www-form-urlencoded");
            var resp = await httpClient.PostAsync(url, reqContent);
            var streamTask = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
            return streamTask;
        }
    }
}
