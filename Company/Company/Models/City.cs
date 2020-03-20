using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Company.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name
        {
            get
            {
                var s = String.Empty;

                switch (Id)
                {
                    case 0:
                        s = "Донецк";
                        break;
                    case 1:
                        s = "Мариуполь";
                        break;
                    case 2:
                        s = "Киев";
                        break;
                    case 3:
                        s = "Одесса";
                        break;
                    default:
                        s = "Донецк";
                        break;
                }
                return s;
            }
        }

        public string Currency
        {
            get
            {
                var c = String.Empty;

                switch (Id)
                {
                    case 0:
                        c = "руб";
                        break;
                    default:
                        c = "грн";
                        break;
                }
                return c;
            }
        }

        public City()
        {
            Id = CrossSettings.Current.GetValueOrDefault("City",0);
        }

        public City(int id)
        {
            Id = id;
        }
    }
}
