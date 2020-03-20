using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Company.Models;
using Newtonsoft.Json;
using Plugin.Settings;
using Xamarin.Forms;

namespace Company.Services
{
    public class RepairData 
    {
        IEnumerable<Option> Options;

        string Url
        {
            get
            {
                if ((bool)Application.Current.Resources["Debug"])
                {
                    return "http://" + (string)Application.Current.Resources["DebugServer"] + "/api/repairs/";
                }
                else
                {
                    return "http://" + (string)Application.Current.Resources["ReleaseServer"] + "/api/repairs/";
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

        public async Task<Repair> Add(Repair repair)
        {
            try
            {
                HttpClient client = GetClient();

                var content = new StringContent( JsonConvert.SerializeObject(repair), Encoding.UTF8, "application/json");

                var str = JsonConvert.SerializeObject(repair);
                var response = await client.PostAsync(Url, content);

                if (response.StatusCode != HttpStatusCode.OK)
                    return null;

                return JsonConvert.DeserializeObject<Repair>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                throw;
            }   
        }
    }
}