using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Company.Models;
using Newtonsoft.Json;

namespace Company.Services
{
    public class CategoryDebug : ICategoryData<Category>
    {
        List<Category> categories;

        string Url = "";

        public CategoryDebug()
        {
            categories = new List<Category>();
            categories.Add(new Category() { MainCategoryId = 0, Id=1, Name = "Проводка", Icon = "main_el.png", Description = "Описание категории работ" });
            //categories.Add(new Category() { MainCategoryId = 0, Name = "Проводка", Icon = "main_el.png", Description = "Описание категории работ" });
        }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<List<Category>> Get()
        {
            HttpClient client = GetClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<List<Category>>(result);
        }

        public async Task<Category> GetItemAsync(int id)
        {
            return await Task.FromResult(categories.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Category>> GetItemsAsync(int mainCategoryid, bool forceRefresh = false)
        {
            try
            {
                return await Task.FromResult(categories.Where(s => s.MainCategoryId == mainCategoryid));
            }
            catch (Exception)
            {
                throw;
            }       
        }

        public async Task<bool> AddItemAsync(Category item)
        {
            categories.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Category item)
        {
            var oldItem = categories.Where((Category arg) => arg.Id == item.Id).FirstOrDefault();
            categories.Remove(oldItem);
            categories.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = categories.Where((Category arg) => arg.Id == id).FirstOrDefault();
            categories.Remove(oldItem);

            return await Task.FromResult(true);
        }


    }
}