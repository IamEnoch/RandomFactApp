using RandomFactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace RandomFactApp.Services
{
    public class RandomFactService
    {
        HttpClient httpClient;

        public RandomFactService()
        {
            httpClient = new HttpClient();
        }

        RandomFact randomFact = new();
        public async Task<RandomFact> GetRandomFactAsync()
        {
            string url = "https://www.boredapi.com/api/activity/";
            List<(string key, string value)> headers = new List<(string key, string value)>
            {
                ("Connection", "keep-alive"),
                ("Accept", "application/json"),
            };
            foreach (var (key, value) in headers)
            {
                httpClient.DefaultRequestHeaders.Add(key, value);
            }

            var response = await httpClient.GetAsync(url);


            if (response.IsSuccessStatusCode)
            {
                // var content = await response.Content.ReadAsStringAsync();

                randomFact = await response.Content.ReadFromJsonAsync<RandomFact>();                
            }
            return randomFact;
        }
    }
}
