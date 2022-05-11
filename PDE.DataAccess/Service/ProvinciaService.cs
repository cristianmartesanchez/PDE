using Newtonsoft.Json;
using PDE.Models.Entities;
using PDE.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PDE.DataAccess.Service
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly HttpClient _httpClient;
        public ProvinciaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private void Initial(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

        }

        public async Task<Provincia> Get(string URL, string accessToken)
        {
            Initial(accessToken);
            var response = await _httpClient.GetAsync(URL);
            try
            {
                response.EnsureSuccessStatusCode();

                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Provincia>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {
                return null;
            }

        }


        public async Task<IEnumerable<Provincia>> GetAll(string URL, string accessToken)
        {
            Initial(accessToken);
            var response = await _httpClient.GetAsync(URL);
            try
            {
                response.EnsureSuccessStatusCode();

                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<Provincia>>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {
                return Enumerable.Empty<Provincia>();
            }

        }
    }
}
