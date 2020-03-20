using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Company.Models
{
    public class Master
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public int WorksDone { get; set; }

        public UriImageSource Image
        {
            get
            {
                return new UriImageSource()
                {
                    CachingEnabled = false,
                    Uri = (bool)Application.Current.Resources["Debug"] ? new Uri("http://" + (string)Application.Current.Resources["DebugServer"] + "/Content/img/" + Photo) :
                    new Uri("http://" + (string)Application.Current.Resources["ReleaseServer"] + "/Content/img/" + Photo)
                };
            }
        } 
    }
}
