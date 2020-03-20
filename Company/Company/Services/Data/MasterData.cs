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
    public class MasterData : IMasterData<Master>
    {
        IEnumerable<Master> Masters;

        string Url
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                {
                    return "http://" + (string)Application.Current.Resources["DebugServer"] + "/api/masters/";
                }
                else
                {
                    return "http://" + (string)Application.Current.Resources["ReleaseServer"] + "/api/masters/";
                }
            }
        }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.Timeout = TimeSpan.FromSeconds(60);
            return client;
        }

        public async Task<IEnumerable<Master>> GetMasters()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url+ CrossSettings.Current.GetValueOrDefault("City", 0));
            return JsonConvert.DeserializeObject<List<Master>>(result);
        }

        public async Task<IEnumerable<Master>> GetMasters(int workId)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + workId + "/"+ CrossSettings.Current.GetValueOrDefault("City", 0));
            return JsonConvert.DeserializeObject<List<Master>>(result);
        }

        public async Task<IEnumerable<Master>> GetItemsAsync(int workId)
        {
            try
            {
                Masters = await GetMasters(workId);

                var result = new List<Master>();

                foreach (var m in Masters)
                {
                    result.Add(m);
                }

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }   
        }

        public async Task<IEnumerable<Master>> GetItemsAsync()
        {
            try
            {
                Masters = await GetMasters();
                var result = new List<Master>();
                foreach (var m in Masters)
                {
                    result.Add(m);
                }
                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}