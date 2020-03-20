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
    public class CategoryData : ICategoryData<Category>
    {
        List<Category> categories;

        string Url
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                {
                    return "http://" + (string)Application.Current.Resources["DebugServer"] + "/api/categories/";
                }
                else
                {
                    return "http://" + (string)Application.Current.Resources["ReleaseServer"] + "/api/categories/";
                }
            }
        }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<List<Category>> Get(int mainCategoryId)
        {
            HttpClient client = GetClient();
            client.Timeout = TimeSpan.FromSeconds(60);
            string result = await client.GetStringAsync(Url+ mainCategoryId+"/"+CrossSettings.Current.GetValueOrDefault("City",0));
            return JsonConvert.DeserializeObject<List<Category>>(result);
        }

        public async Task<IEnumerable<Category>> GetItemsAsync(int mainCategoryid, bool forceRefresh = false)
        {
            try
            {
                categories = await Get(mainCategoryid);
                return await Task.FromResult(categories);
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