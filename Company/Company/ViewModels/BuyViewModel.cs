using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Company.Models;
using Company.Views;
using Xamarin.Forms;

namespace Company.ViewModels
{
    public class BuyViewModel : BaseViewModel
    {
        private Repair repair;
        public Repair Repair { get { return repair; } set { SetProperty(ref repair, value); } }
 
        public Command LoadItemsCommand { get; set; }

        BuyPage Page;

        DateTime LastAction;

        public BuyViewModel(Repair repair, BuyPage page)
        {
            Repair = repair;

            Page = page;

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            if (LastAction != null && LastAction.AddMinutes(5) > DateTime.Now)
            {
                Page.Shackle();
                return;
            }

            IsBusy = true;

            Page.Buy.Text = "Отправка запроса";
            Page.Buy.BackgroundColor = Color.FromHex("#2f669a");

            try
            {
                await Task.Delay(1500);

                if (Repair != null)
                    await RepairStore.Add(Repair);

                LastAction = DateTime.Now;
                IsBusy = false;
                Page.Buy.Text = "Запрос отправлен";
                Page.Buy.BackgroundColor = Color.Green;
                await Page.Navigation.PushModalAsync(new ThanksPage(),true);
            }
            catch (Exception)
            {
                Page.Buy.Text = "Ошибка запроса";
                Page.Buy.BackgroundColor = Color.PaleVioletRed;
                IsBusy = false;
            }
        }
    }
}
