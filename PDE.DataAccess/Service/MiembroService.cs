﻿using Newtonsoft.Json;
using PDE.Models.Entities;
using PDE.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PDE.DataAccess.Service
{
    public class MiembroService : IMiembroService
    {
        private readonly HttpClient _httpClient;
        public MiembroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private void Initial(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            
        }

        public async Task<Miembro> Get(string URL, string accessToken)
        {

            Initial(accessToken);
            var response = await _httpClient.GetAsync(URL);

            try
            {
                response.EnsureSuccessStatusCode();
                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Miembro>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {
                return null;
            }

            
        }


        public async Task<IEnumerable<Miembro>> GetAll(string URL, string accessToken)
        {
            Initial(accessToken);
            var response = await _httpClient.GetAsync(URL);

            try
            {
                response.EnsureSuccessStatusCode();
                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<Miembro>>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {
                return Enumerable.Empty<Miembro>();
            }

        }

        public async Task<Miembro> Post(string url, object body, string accessToken)
        {
            Initial(accessToken);
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            try
            {
                response.EnsureSuccessStatusCode();

                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Miembro>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {
                return null;
            }

            
        }

        public async Task<Miembro> Put(string url, object body, string accessToken)
        {
            Initial(accessToken);
            var json = JsonConvert.SerializeObject(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, content);

            try
            {
                response.EnsureSuccessStatusCode();

                var respnoseText = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Miembro>(respnoseText);
                return data;
            }
            catch (HttpRequestException)
            {

                return null;
            }


        }

    }
}