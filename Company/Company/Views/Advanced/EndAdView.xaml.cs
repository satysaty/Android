using Company.Models;
using Company.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views.Advanced
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EndAdView : ContentView
	{
        EndAdViewModel viewModel;

        Repair Repair;

        public EndAdView(Repair repair, IEnumerable<WorkOption> workOptions)
        {
            InitializeComponent();


            BindingContext = this.viewModel = new EndAdViewModel(repair, workOptions);
        }

        private async void SelectAdListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var option = e.SelectedItem as Option;
            if (option == null)
                return;

            EndAdListView.SelectedItem = null;
            await viewModel.AddOption(option);

            //await Navigation.PushAsync(), true);

            // Manually deselect item.
            //SelectAdListView.SelectedItem = null;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BuyPage(viewModel.Repair), true);
        }
    }
}