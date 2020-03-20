using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Company.Models;
using Company.Views;

namespace Company.ViewModels
{
    public class MainCategoryViewModel : BaseViewModel
    {
        public ObservableCollection<MainCategory> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        public MainCategoryViewModel()
        {
            Title = "Категории";
            Items = new ObservableCollection<MainCategory>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            ErrorVisible = false;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await MainCategoryStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
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