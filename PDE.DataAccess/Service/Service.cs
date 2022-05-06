using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PDE.DataAccess.Service
{
    public class Service 
    {
        private string URlBase = "https://localhost:7295/api/";
        //public async Task<T> Get(string url)
        //{
        //    T data = null;
        //    using (var httpClient = new HttpClient())
        //    {
        //        string URL = URlBase + "" + url;
        //        var response = await httpClient.GetAsync(URL);
        //        string apiResponse = await response.Content.ReadAsStringAsync();
        //        data = JsonConvert.DeserializeObject<T>(apiResponse);
        //    }

        //    return data;
        //}

        //public async Task<IEnumerable<T>> GetAll(string url)
        //{
        //    IEnumerable<T> data = null;
        //    using (var httpClient = new HttpClient())
        //    {
        //        string URL = URlBase + "" + url;
        //        var response = await httpClient.GetAsync(URL);
        //        string apiResponse = await response.Content.ReadAsStringAsync();
        //        data = JsonConvert.DeserializeObject<IEnumerable<T>>(apiResponse);
        //    }

        //    return data;
        //}

        //public async Task<T> Insert(string url, T model)
        //{
        //    T data = null;
        //    using (var httpClient = new HttpClient())
        //    {
        //        string URL = URlBase + "" + url;
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "aplication/json");

        //        var response = await httpClient.PostAsync(URL, content);
        //        string apiResponse = await response.Content.ReadAsStringAsync();

        //        data = JsonConvert.DeserializeObject<T>(apiResponse);
        //    }

        //    return data;
        //}

        //public async Task<T> Update(string url, T model)
        //{
        //    T data = null;
        //    string URL = URlBase + "" + url;
        //    using (var httpClient = new HttpClient())
        //    {
                
        //        StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "aplication/json");

        //        var response = await httpClient.PutAsync(URL, content);
        //        string apiResponse = await response.Content.ReadAsStringAsync();

        //        data = JsonConvert.DeserializeObject<T>(apiResponse);
        //    }

        //    return data;
        //}


    }
}
