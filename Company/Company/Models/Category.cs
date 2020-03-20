using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Company.Models
{
    public class Category
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public int MainCategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }
}
