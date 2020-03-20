using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Company.Models;
using Company.Views;
using Plugin.Settings;
using Xamarin.Forms;

namespace Company.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public MainCategory MainCategory { get; set; }

        public ObservableCollection<Category> Categories { get; set; }

        public Command LoadItemsCommand { get; set; }

        private bool errorItemsVisible;
        public bool ErrorItemsVisible
        {
            get
            {
                return errorItemsVisible;
            }
            set
            {
                errorItemsVisible = value;
                OnPropertyChanged("ErrorItemsVisible");
            }
        }

        public CategoryViewModel(MainCategory mainCategory)
        {
            Title = mainCategory.Name;

            MainCategory = mainCategory;

            Categories = new ObservableCollection<Category>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            ErrorVisible = false;
            
            ErrorItemsVisible = false;

            IsBusy = true;

            try
            {
                Categories.Clear();
                var categories = await CategoryStore.GetItemsAsync(MainCategory.Id, true);
                if (categories.Count() == 0)
                {
                    IsBusy = false;
                    ErrorItemsVisible = true;
                    return;
                }

                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
                OnPropertyChanged("Categories");
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
