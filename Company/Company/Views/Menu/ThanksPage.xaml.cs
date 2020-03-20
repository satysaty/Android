using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThanksPage : ContentPage
    {
        public ThanksPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}