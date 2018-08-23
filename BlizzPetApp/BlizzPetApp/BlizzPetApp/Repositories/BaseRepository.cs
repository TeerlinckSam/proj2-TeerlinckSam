using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlizzPetApp.Repositories
{
    public class BaseRepository
    {

        private const string _BLIZZPETID = "crrwjd3h9hrmr6je6gpjdzfvft276krr";
        private const string _BLIZZPETSECRET = "y6E3vNXPXWv3d6B4AtM2hShryPyqjft3";

        private const string _API_KEY = _BLIZZPETID;

        private HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            //client.DefaultRequestHeaders.Add("x-app-id", _BLIZZPETSECRET);
            //client.DefaultRequestHeaders.Add("x-app-key", _API_KEY);
            return client;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            using (HttpClient client = CreateHttpClient())
            {
                try
                {
                    var json =  client.GetStringAsync(url).GetAwaiter().GetResult();
                    Debug.WriteLine(json);
                    return  JsonConvert.DeserializeObject<T>(json);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return default(T);
                }
            }
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            using (HttpClient client = CreateHttpClient())
            {
                var json = JsonConvert.SerializeObject(data);

                try
                {
                    var result = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                    if (result.IsSuccessStatusCode)
                    {
                        string x = await result.Content.ReadAsStringAsync();
                        return await Task.Run(() => JsonConvert.DeserializeObject<T>(x));
                    }
                    return default(T);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return default(T);
                }
            }
        }

    }
}
