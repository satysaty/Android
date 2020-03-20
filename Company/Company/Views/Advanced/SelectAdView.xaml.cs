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
	public partial class SelectAdView : ContentView
	{
        SelectAdViewModel viewModel;

        IEnumerable<WorkOption> WorkOptions;

        public SelectAdView(Repair repair, IEnumerable<WorkOption> workOptions)
		{
			InitializeComponent ();

            WorkOptions = workOptions;

            BindingContext = this.viewModel = new SelectAdViewModel(repair, workOptions);
        }

        private async void SelectAdListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            var option = e.SelectedItem as Option;
            if (option == null)
                return;

            SelectAdListView.SelectedItem = null;
            await viewModel.AddOption(option);

            if (WorkOptions.Where(x => x != viewModel.CurrentWorkOption).FirstOrDefault() != null)
                await Navigation.PushAsync(new AdvancedWorkPage(viewModel.Repair, WorkOptions.Where(x => x != viewModel.CurrentWorkOption).ToArray()), true);
            else
                await Navigation.PushAsync(new BuyPage(viewModel.Repair), true);

            // Manually deselect item.
            //SelectAdListView.SelectedItem = null;
        }

    }
}