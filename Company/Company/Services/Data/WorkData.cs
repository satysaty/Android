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
    public class WorkData : IWorkData<Work>
    {
        List<Work> works;

        string Url
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                {
                    return "http://" + (string)Application.Current.Resources["DebugServer"] +"/api/works/";
                }
                else
                {
                    return "http://" + (string)Application.Current.Resources["ReleaseServer"] + "/api/works/";
                }
            }
        }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<List<Work>> Get(int categoryId)
        {
            HttpClient client = GetClient();
            client.Timeout = TimeSpan.FromSeconds(60);
            string result = await client.GetStringAsync(Url + categoryId +"/"+CrossSettings.Current.GetValueOrDefault("City",0));
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
                works = await Get(categoryid);
                return await Task.FromResult(works);
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