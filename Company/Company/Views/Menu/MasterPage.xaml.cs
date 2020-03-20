using Company.Services;
using Company.ViewModels;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
	{
        MasterViewModel viewModel;

        Inet Inet;

        bool Animation;

        public MasterPage()
        {
            InitializeComponent();

            BindingContext = this.viewModel = new MasterViewModel();

            Inet = new Inet(Navigation, viewModel.LoadItemsCommand);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

           // if(viewModel.Masters.Count == 0)
                Inet.Check();
        }

        private void ButtonRetry_Clicked(object sender, EventArgs e)
        {
            Inet.Check();
        }

        private async void ErrorVisible_Changed(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Animation)
                return;
            if (e.PropertyName == "IsVisible")
                if (ErrorFrame.IsVisible)
                {
                    Animation = true;
                    ErrorFrame.TranslationX = -300;
                    ButtonRetry.TranslationX = 300;
                    
                    new Thread(async() => {
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

        private void Button_Clicked_1(object sender, EventArgs e)
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
    }
}