using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PDE.DataAccess.Service
{
    public class HttpClientWrapper
    {
        private readonly HttpClient _client;

        public HttpClientWrapper(HttpClient client)
        {
            _client = client;
        }

        public HttpClient Client => _client;
        private string UrlBase = "https://localhost:7295/api";

        public async Task<T> GetAsync<T>(string url)
        {
            string URL = $"{UrlBase}{url}";

            var response = await _client.GetAsync(URL);

            response.EnsureSuccessStatusCode();

            var respnoseText = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(respnoseText);
            return data;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string url)
        {
            string URL = $"{UrlBase}{url}";

            var response = await _client.GetAsync(URL);

            //response.EnsureSuccessStatusCode();

            var respnoseText = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<T>>(respnoseText);
            return data;
        }

        public async Task<T> PostAsync<T>(string url, object body)
        {
            string URL = $"{UrlBase}{url}";
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(URL, content);

           // response.EnsureSuccessStatusCode();

            var respnoseText = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(respnoseText);
            return data;
        }

        public async Task PostAsync(string url, object body)
        {
            string URL = $"{UrlBase}{url}";
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(URL, content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<T> PutAsync<T>(string url, object body)
        {
            string URL = $"{UrlBase}{url}";
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(URL, content);

            response.EnsureSuccessStatusCode();

            var respnoseText = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(respnoseText);
            return data;
        }
    }
}
