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
    public class WorkOptionData : IOptionData<WorkOption>
    {
        IEnumerable<WorkOption> Options;

        string Url
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                {
                    return "http://" + (string)Application.Current.Resources["DebugServer"] + "/api/workoptions/";
                }
                else
                {
                    return "http://" + (string)Application.Current.Resources["ReleaseServer"] + "/api/workoptions/";
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

        public async Task<IEnumerable<WorkOption>> GetOptions(int workId)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + workId + "/"+ CrossSettings.Current.GetValueOrDefault("City", 0));
            return JsonConvert.DeserializeObject<List<WorkOption>>(result);
        }

        public async Task<IEnumerable<WorkOption>> GetItemsAsync(int workId)
        {
            try
            {
                Options = await GetOptions(workId);

                var result = new List<WorkOption>();

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