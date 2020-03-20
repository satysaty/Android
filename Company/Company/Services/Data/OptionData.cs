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
    public class OptionData : IOptionData<Option>
    {
        IEnumerable<Option> Options;

        string Url
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                {
                    return "http://" + (string)Application.Current.Resources["DebugServer"] + "/api/options/";
                }
                else
                {
                    return "http://" + (string)Application.Current.Resources["ReleaseServer"] + "/api/options/";
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

        public async Task<IEnumerable<Option>> GetOptions(int workId)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + workId + "/"+ CrossSettings.Current.GetValueOrDefault("City", 0));
            return JsonConvert.DeserializeObject<List<Option>>(result);
        }

        public async Task<IEnumerable<Option>> GetItemsAsync(int workId)
        {
            try
            {
                Options = await GetOptions(workId);

                var result = new List<Option>();

                foreach (var m in Options)
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