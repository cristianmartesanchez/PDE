using Newtonsoft.Json;
using PDE.Models.Entities;
using PDE.Models.Entities.Padron;
using PDE.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PDE.DataAccess.Service
{
    public class PadronService : IPadronService
    {
        private readonly HttpClient _httpClient;
        public PadronService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Padron> Get(string URL)
        {
            
            var response = await _httpClient.GetAsync(URL);
            try
            {
                response.EnsureSuccessStatusCode();

                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Padron>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {

                return null;
            }

        }


        public async Task<IEnumerable<Padron>> GetAll(string URL)
        {
            var response = await _httpClient.GetAsync(URL);
            try
            {
                response.EnsureSuccessStatusCode();

                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<Padron>>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {

               return Enumerable.Empty<Padron>();
            }

        }
    }
}
