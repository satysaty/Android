using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Company.Models;
using Company.Views;
using Xamarin.Forms;

namespace Company.ViewModels
{
    public class PriceViewModel : BaseViewModel
    {
        public Work Work { get; set; }

        public Command LoadItemsCommand { get; set; }

        public IEnumerable<WorkOption> WorkOptions { get; set; }

        bool adWorkButton = false;
        public bool AdWorkButton
        {
            get { return adWorkButton; }
            set
            {
                SetProperty(ref adWorkButton, value);
            }
        }

        public PriceViewModel(Work work)
        {
            Work = work;

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            ErrorVisible = false;

            try
            {
                await Task.Delay(200);

                WorkOptions = await WorkOptionData.GetItemsAsync(Work.Id);

                if (WorkOptions.Count() != 0)
                    AdWorkButton = true;
                else
                    AdWorkButton = false;

                IsBusy = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                IsBusy = false;
                Content = false;
                ErrorVisible = true;
            }
        }
    }
}
