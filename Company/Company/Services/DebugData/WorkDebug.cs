using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Company.Models;
using Newtonsoft.Json;

namespace Company.Services
{
    public class WorkDebug : IWorkData<Work>
    {
        List<Work> works;

        string Url = "";

        public WorkDebug()
        {
            works = new List<Work>();
            works.Add(new Work() { CategoryId = 1, Name = "Установить розетку", Price = 400, Description = "Описание работы" });
            works.Add(new Work() { CategoryId = 1, Name = "Убрать розетку", Price = 200, Description = "Описание работы" });
            works.Add(new Work() { CategoryId = 1, Name = "Расширить розетку", Price = 100, Description = "Описание работы" });
        }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<List<Work>> Get(int categoryId, int city)
        {
            HttpClient client = GetClient();
            client.Timeout = TimeSpan.FromSeconds(5);
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<List<Work>>(result);
        }

        public async Task<Work> GetItemAsync(int id)
        {
            return await Task.FromResult(works.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Work>> GetItemsAsync(int categoryid, bool forceRefresh = false)
        {
            try
            {
                return await Task.FromResult(works.Where(s => s.CategoryId == categoryid));
            }
            catch (Exception)
            {
                throw;
            }   
        }

        public async Task<bool> AddItemAsync(Work item)
        {
            works.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Work item)
        {
            var oldItem = works.Where((Work arg) => arg.Id == item.Id).FirstOrDefault();
            works.Remove(oldItem);
            works.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = works.Where((Work arg) => arg.Id == id).FirstOrDefault();
            works.Remove(oldItem);

            return await Task.FromResult(true);
        }


    }
}