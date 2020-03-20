using System;
using Plugin.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectCityPage : ContentPage
    {
        public SelectCityPage()
        {
            InitializeComponent();
        }

        protected async override void OnDisappearing()
        {
            if (CrossSettings.Current.GetValueOrDefault("City", -1) == -1)
            {
                await Navigation.PushModalAsync(new SelectCityPage(), true);
            }

            base.OnDisappearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CrossSettings.Current.AddOrUpdateValue("City", 0);

            Application.Current.MainPage = new MainPage();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            CrossSettings.Current.AddOrUpdateValue("City", 1);

            Application.Current.MainPage = new MainPage();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            CrossSettings.Current.AddOrUpdateValue("City", 2);

            Application.Current.MainPage = new MainPage();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            CrossSettings.Current.AddOrUpdateValue("City", 3);

            Application.Current.MainPage = new MainPage();
        }
    }
}