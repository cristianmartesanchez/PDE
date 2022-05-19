using Newtonsoft.Json;
using PDE.Models.Dto;
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
    public class CargosTerritorialesService : ICargosTerritorialesService
    {
        private readonly HttpClient _httpClient;
        public CargosTerritorialesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private void Initial(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

        }

        public async Task<CargoTerritorialDto> Get(string URL, string accessToken)
        {
            Initial(accessToken);
            var response = await _httpClient.GetAsync(URL);
            try
            {
                response.EnsureSuccessStatusCode();

                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CargoTerritorialDto>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {
                return null;
            }

        }


        public async Task<IEnumerable<CargoTerritorialDto>> GetAll(string URL, string accessToken)
        {
            Initial(accessToken);
            var response = await _httpClient.GetAsync(URL);
            try
            {
                response.EnsureSuccessStatusCode();

                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<CargoTerritorialDto>>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {

                return Enumerable.Empty<CargoTerritorialDto>();
            }

        }

        public async Task<CargoTerritorialDto> Post(string url, object body, string accessToken)
        {
            Initial(accessToken);
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            try
            {
                response.EnsureSuccessStatusCode();

                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CargoTerritorialDto>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {

                return null;
            }


        }

        public async Task<CargoTerritorialDto> Put(string url, object body, string accessToken)
        {
            Initial(accessToken);
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            try
            {
                response.EnsureSuccessStatusCode();

                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CargoTerritorialDto>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {

                return null;
            }


        }

        public async Task<bool> Delete(string url, string accessToken)
        {
            Initial(accessToken);
            var response = await _httpClient.DeleteAsync(url);
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
