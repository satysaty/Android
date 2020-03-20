using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Company.Models
{
    public class MainCategory
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }
}
