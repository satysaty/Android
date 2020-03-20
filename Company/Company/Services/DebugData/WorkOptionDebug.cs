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
    public class WorkOptionDebug : IOptionData<WorkOption>
    {
        List<WorkOption> WorkOptions;

        public WorkOptionDebug()
        {
            var options = new List<WorkOption>();

            //options.Add(new WorkOption()
            //{
            //    WorkId = 1,
            //    Name = "Установить шайбы?",
            //    CityId = 0,
            //    Id = 1,
            //});
            //options.Add(new WorkOption()
            //{
            //    WorkId = 1,
            //    Name = "Помыть пол?",
            //    CityId = 0,
            //    Id = 2,
            //});
            //options.Add(new WorkOption()
            //{
            //    WorkId = 1,
            //    Name = "и третья что нужно сделать",
            //    CityId = 0,
            //    Id = 3,
            //});

            WorkOptions = options;
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

        public async Task<IEnumerable<WorkOption>> GetItemsAsync(int workId)
        {
            try
            {
                //WorkOptions = await Get();

                return await Task.FromResult(WorkOptions);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}