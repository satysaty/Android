using Company.Models;
using Company.Services;
using Company.ViewModels;
using Company.Views.Advanced;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PricePage : ContentPage
    {
        PriceViewModel viewModel;

        Inet Inet;

        Work Work;

        bool Animation;

        public PricePage(Work work)
        {
            InitializeComponent();

            BindingContext = this.viewModel = new PriceViewModel(work);

            Work = work;
            
            Inet = new Inet(Navigation, viewModel.LoadItemsCommand);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Inet.Check();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var repair = new Repair() { Work = Work, CityId = Work.CityId, Options = new List<Option>() };
            Navigation.PushAsync(new BuyPage(repair), true);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var repair = new Repair() { Work = Work, CityId = Work.CityId, Options = new List<Option>() };
            await Navigation.PushAsync(new AdvancedWorkPage(repair, viewModel.WorkOptions), true);
        }

        private async void ActivityIndicator_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
            if (e.PropertyName == "IsRunning")
                if (ActivityIndicator.IsRunning)
                {
                    ButtonContent.FadeTo(0.0, 500);
                    await ButtonContent.TranslateTo(ButtonContent.TranslationX, ButtonContent.TranslationY + 120, 500);
                }
                else
                {
                    ButtonContent.TranslationY = 120;
                    ButtonContent.FadeTo(1.0, 500);
                    await ButtonContent.TranslateTo(ButtonContent.TranslationX, ButtonContent.TranslationY - 120, 500);
                }
        }

        private void ButtonRetry_Clicked(object sender, EventArgs e)
        {
            Inet.Check();
        }

        private async void Error_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Animation)
                return;
            if (e.PropertyName == "IsVisible")
                if (Error.IsVisible)
                {
                    Animation = true;
                    Error.TranslationX = -300;
                    ButtonRetry.TranslationX = 300;

                    new Thread(async () => {
                        await Error.TranslateTo(Error.TranslationX + 320, Error.TranslationY, 150);
                        await Error.TranslateTo(Error.TranslationX - 50, Error.TranslationY, 40);
                        await Error.TranslateTo(Error.TranslationX + 50, Error.TranslationY, 50);
                        await Error.TranslateTo(Error.TranslationX - 20, Error.TranslationY, 40);
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
                    Error.TranslationX = -300;
                    ButtonRetry.TranslationX = 300;
                }
        }
    }
}