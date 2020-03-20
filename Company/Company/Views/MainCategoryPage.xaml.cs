using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Company.Models;
using Company.Views;
using Company.ViewModels;
using Plugin.Settings;

namespace Company.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainCategoryPage : ContentPage
    {
        MainCategoryViewModel viewModel;

        public MainCategoryPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MainCategoryViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as MainCategory;
            if (item == null)
                return;

             await Navigation.PushAsync(new CategoryPage(new CategoryViewModel(item)),true);

            // Manually deselect item.
            MainCategoryListView.SelectedItem = null;
        }
 
        protected override void OnAppearing()
        {
            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);

            base.OnAppearing();
        }
    }
}