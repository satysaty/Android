using Company.Services.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Company.Models
{
    public class Option
    {
        [JsonIgnore]
        public OptionView OptionView { get;set;}

        public int Id { get; set; }

        public string Name { get; set; }

        public int? Price { get; set; }

        public Option()
        {
            OptionView = new OptionView();
        }
    }

    public class OptionView : NotifyProperty
    {
        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                SetProperty(ref isSelected, value);
            }
        }
    }
}
