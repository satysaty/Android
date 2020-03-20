using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Company.Models;
using Newtonsoft.Json;
using Plugin.Settings;
using Xamarin.Forms;

namespace Company.Services
{
    public class OptionDebug : IOptionData<Option>
    {
        List<Option> Options;

        public OptionDebug()
        {
            var options = new List<Option>();

            //options.Add(new Option()
            //{
            //    WorkId = 1,
            //    Name = "Тест",
            //    CityId = 0,
            //    WorkOptionId = 1,
            //    Id = 1,
            //    Class = 1,
            //    Price = 100
            //});
            //options.Add(new Option()
            //{
            //    WorkId = 1,
            //    Name = "Тест",
            //    CityId = 0,
            //    WorkOptionId = 1,
            //    Id = 2,
            //    Class = 1,
            //    Price = 200
            //});
            //options.Add(new Option()
            //{
            //    WorkId = 1,
            //    Name = "Тест",
            //    CityId = 0,
            //    WorkOptionId = 1,
            //    Id = 3,
            //    Class = 1,
            //    Price = 300
            //});
            //options.Add(new Option()
            //{
            //    WorkId = 1,
            //    Name = "Тест",
            //    CityId = 0,
            //    WorkOptionId = 1,
            //    Id = 4,
            //    Class = 1,
            //    Price = 0
            //});

            //options.Add(new Option()
            //{
            //    WorkId = 1,
            //    Name = "Тест",
            //    CityId = 0,
            //    WorkOptionId = 2,
            //    Id = 5,
            //    Class = 2,
            //    Price = 300
            //});
            //options.Add(new Option()
            //{
            //    WorkId = 1,
            //    Name = "Тест",
            //    CityId = 0,
            //    WorkOptionId = 2,
            //    Id = 6,
            //    Class = 2,
            //    Price = 0
            //});

            //options.Add(new Option()
            //{
            //    WorkId = 1,
            //    Name = "Тест",
            //    CityId = 0,
            //    WorkOptionId = 3,
            //    Id = 7,
            //    Class = 3,
            //    Price = 300
            //});
            //options.Add(new Option()
            //{
            //    WorkId = 1,
            //    Name = "Тест",
            //    CityId = 0,
            //    WorkOptionId = 3,
            //    Id = 8,
            //    Class = 3,
            //    Price = 0
            //});

            Options = options;
        }

        string Url = "";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<List<Option>> Get()
        {
            HttpClient client = GetClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<List<Option>>(result);
        }

        public async Task<IEnumerable<Option>> GetItemsAsync(int workId)
        {
            try
            {
                //Options = await Get();

                return await Task.FromResult(Options);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}