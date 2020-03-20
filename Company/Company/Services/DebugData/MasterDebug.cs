using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Company.Models;
using Newtonsoft.Json;

namespace Company.Services
{
    public class MasterDebug : IMasterData<Master>
    {
        List<Master> Masters;

        string UrlMastersWorks = "";

        string Url = "";

        public MasterDebug()
        {
            Masters = new List<Master>();
            Masters.Add(new Master() { Name="Vladislav", Id=1, Photo="ava.png"});
            Masters.Add(new Master() { Name="Vladimir", Id=2, Photo="ava.png"});
        }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Master>> GetMasters()
        {
            HttpClient client = GetClient();
            client.Timeout = TimeSpan.FromSeconds(5);
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<List<Master>>(result);
        }

        public async Task<IEnumerable<MasterWork>> GetMastersWorks()
        {
            HttpClient client = GetClient();
            client.Timeout = TimeSpan.FromSeconds(5);
            string result = await client.GetStringAsync(UrlMastersWorks);
            return JsonConvert.DeserializeObject<List<MasterWork>>(result);  
        }

        public async Task<IEnumerable<Master>> GetItemsAsync()
        {
            try
            {
                return await Task.FromResult(Masters);
            }
            catch (Exception)
            {
                throw;
            }   
        }

        public async Task<IEnumerable<Master>> GetItemsAsync(int workid)
        {
            try
            {


                return await Task.FromResult(Masters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Master> GetItemAsync(int id)
        {
            return await Task.FromResult(Masters.FirstOrDefault(s => s.Id == id));
        }

        public async Task<bool> AddItemAsync(Master item)
        {
            //Masters.to Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Master item)
        {
           // var oldItem = Masters.Where((Master arg) => arg.Id == item.Id).FirstOrDefault();
            //Masters.Remove(oldItem);
           // Masters.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
          //  var oldItem = masters.Where((Master arg) => arg.Id == id).FirstOrDefault();
          //  Masters.Remove(oldItem);

            return await Task.FromResult(true);
        }


    }
}