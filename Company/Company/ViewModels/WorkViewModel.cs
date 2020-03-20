using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Company.Models;
using Company.Views;
using Xamarin.Forms;

namespace Company.ViewModels
{
    public class WorkViewModel : BaseViewModel
    {
        public Category Category { get; set; }

        public ObservableCollection<Work> Works { get; set; }

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

        public WorkViewModel(Category category)
        {
            Title = category.Name;

            Category = category;

            Works = new ObservableCollection<Work>();

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
                await Task.Delay(100);
                Works.Clear();
                var works = await WorkStore.GetItemsAsync(Category.Id, true);
                if (works.Count() == 0)
                {
                    IsBusy = false;
                    ErrorItemsVisible = true;
                    return;
                }
                foreach (var work in works)
                {
                    Works.Add(work);
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
