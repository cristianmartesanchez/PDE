using Newtonsoft.Json;
using PDE.Models.Entities;
using PDE.Models.Entities.Identity;
using PDE.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PDE.DataAccess.Service
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly HttpClient _httpClient;
        public AuthenticateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TokenModel> Login(string url, object body)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            try
            {
                response.EnsureSuccessStatusCode();

                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<TokenModel>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<bool> Post(string url, object body)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            try
            {
                response.EnsureSuccessStatusCode();

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }

            
        }

        public async Task<bool> Put(string url, object body)
        {
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            try
            {
                response.EnsureSuccessStatusCode();

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {

                return false;
            }


        }

    }
}
