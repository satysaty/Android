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
    public class SelectAdViewModel : BaseViewModel
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

        public WorkOption CurrentWorkOption
        {
            get
            {
                return WorkOptions.FirstOrDefault();
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

        public SelectAdViewModel(Repair repair, IEnumerable<WorkOption> workOptions)
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
                    var s = WorkOptions.SelectMany(o => o.Options).ToList();
                    foreach (var option in Repair.Options.Where(x => WorkOptions.SelectMany(o => o.Options).Contains(x)).ToList())
                    //foreach (var option in Repair.Options.Where(x => CurrentWorkOption.Options.Contains(x)))
                    {
                        Repair.Options.Remove(option);
                    }
                }

                Repair.Options.Add(addOption);

                OnPropertyChanged("Repair");

                foreach (var option in WorkOptions.SelectMany(o => o.Options).ToList())
                {
                    if (option != addOption)
                        option.OptionView.IsSelected = false;
                    else
                        option.OptionView.IsSelected = true;
                }

               // var s = CurrentWorkOption.Options.Where(x => x == addOption).FirstOrDefault();

               // s.OptionView.IsSelected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}