using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoInternetPage : ContentPage
	{
		public NoInternetPage()
		{
            InitializeComponent();
        }

        protected async override void OnDisappearing()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await Navigation.PushModalAsync(new NoInternetPage(), true);
            }

            base.OnDisappearing();
        }
    }
}