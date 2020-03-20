using Company.Models;
using Company.Services;
using Company.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkMastersPage : ContentPage
    {
        WorkMastersViewModel viewModel;

        Inet Inet;

        Repair Repair;

        bool Animation;

        public WorkMastersPage(Work work)
        {
            InitializeComponent();

            Repair = new Repair() { Work = work, CityId = work.CityId, Options = new List<Option>() };

            BindingContext = this.viewModel = new WorkMastersViewModel(work);

            Inet = new Inet(Navigation, viewModel.LoadItemsCommand);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Inet.Check();
        }

        private async void ErrorVisible_Changed(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Animation)
                return;
            if (e.PropertyName == "IsVisible")
                if (viewModel.ErrorVisible)
                {
                    Animation = true;
                    ErrorFrame.TranslationX = -300;
                    ButtonRetry.TranslationX = 300;

                    new Thread(async () => {
                        await ErrorFrame.TranslateTo(ErrorFrame.TranslationX + 320, ErrorFrame.TranslationY, 150);
                        await ErrorFrame.TranslateTo(ErrorFrame.TranslationX - 50, ErrorFrame.TranslationY, 40);
                        await ErrorFrame.TranslateTo(ErrorFrame.TranslationX + 50, ErrorFrame.TranslationY, 50);
                        await ErrorFrame.TranslateTo(ErrorFrame.TranslationX - 20, ErrorFrame.TranslationY, 40);
                    }).Start();

                    new Thread(async () => {
                        await ButtonRetry.TranslateTo(ButtonRetry.TranslationX - 320, ButtonRetry.TranslationY, 150);
                        await ButtonRetry.TranslateTo(ButtonRetry.TranslationX + 50, ButtonRetry.TranslationY, 40);
                        await ButtonRetry.TranslateTo(ButtonRetry.TranslationX - 50, ButtonRetry.TranslationY, 50);
                        await ButtonRetry.TranslateTo(ButtonRetry.TranslationX + 20, ButtonRetry.TranslationY, 40);
                    }).Start();
                    await Task.Delay(300);
                    Animation = false;
                }
                else
                {
                    ErrorFrame.TranslationX = -300;
                    ButtonRetry.TranslationX = 300;
                }
        }

        private void ButtonRetry_Clicked(object sender, EventArgs e)
        {
            Inet.Check();
        }

        private async void ActivityIndicator_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsRunning")
                if (ActivityIndicator.IsRunning)
                {
                    await Content.TranslateTo(Content.TranslationX, Content.TranslationY + 30, 170);
                }
                else
                {
                    await Content.TranslateTo(Content.TranslationX, Content.TranslationY - 30, 170);
                }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuyPage(Repair), true);
        }
    }
}