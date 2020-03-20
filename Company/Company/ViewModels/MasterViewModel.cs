using Company.Models;
using Company.Views;
using Plugin.Settings;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace Company.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        public ObservableCollection<Master> Masters { get; set; }

        public Command LoadItemsCommand { get; set; }

        public MasterViewModel()
        {
            Masters = new ObservableCollection<Master>();
            LoadItemsCommand = new Command(async () => await LoadMastersCommand());
        }

        async Task LoadMastersCommand()
        {
            if (IsBusy)
                return;

            ErrorVisible = false;

            IsBusy = true;
            
            try
            {
                await Task.Delay(100);
                Masters.Clear();
                var masters = await MasterStore.GetItemsAsync();
                if (masters.Count() == 0)
                {
                    IsBusy = false;
                    Content = false;
                    ErrorVisible = true;
                    return;
                }
                foreach (var master in masters)
                {
                    Masters.Add(master);
                }
                
                OnPropertyChanged("Masters");
                IsBusy = false;
            }
            catch (Exception)
            {
                IsBusy = false;
                Content = false;
                ErrorVisible = true;
            }
        }
    }
}