using Company.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace Company.ViewModels
{
    public class EndAdViewModel : BaseViewModel
    {
        public ObservableCollection<Option> OptionsView
        {
            get
            {
                return new ObservableCollection<Option>(WorkOptions.FirstOrDefault().Options);
            }
        }

        public IEnumerable<WorkOption> WorkOptions { get; set; }

        public string WorkOptionName
        {
            get
            {
                return WorkOptions.FirstOrDefault().Name;
            }
        }

        private Repair repair;

        public Repair Repair
        {
            get
            {
                return repair;
            }
            set
            {
                SetProperty(ref repair, value);
            }
        }

        public EndAdViewModel(Repair repair, IEnumerable<WorkOption> workOptions)
        {
            WorkOptions = workOptions;

            Repair = repair;
        }

        public async Task AddOption(Option addOption)
        {
            try
            {
                if (Repair.Options != null)
                {
                    if (!addOption.OptionView.IsSelected)
                    {
                        Repair.Options.Add(addOption);
                    }
                    else
                    {
                        Repair.Options.Remove(addOption);
                    }
                }

                OnPropertyChanged("Repair");

                if (!addOption.OptionView.IsSelected)
                    addOption.OptionView.IsSelected = true;
                else
                    addOption.OptionView.IsSelected = false;
            }
            catch (Exception)
            {
            }
        }
    }
}