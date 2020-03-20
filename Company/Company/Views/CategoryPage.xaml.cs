using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Company.Models;
using Company.ViewModels;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Company.Services;
using System.Threading;

namespace Company.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        CategoryViewModel viewModel;

        Inet Inet;

        bool Animation;

        public CategoryPage(CategoryViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            Inet = new Inet(Navigation, viewModel.LoadItemsCommand);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var category = args.SelectedItem as Category;
            if (category == null)
                return;
            
            await Navigation.PushAsync(new WorkPage(new WorkViewModel(category)), true);

            // Manually deselect item.
            CategoryListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            if (viewModel.Categories.Count == 0)
                Inet.Check(true);
        }

        private async void ErrorItemsVisible_Changed(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Animation)
                return;
            if (e.PropertyName == "IsVisible")
                if (ErrorItems.IsVisible)
                {
                    Animation = true;
                    CategoryListView.IsPullToRefreshEnabled = false;
                    ErrorItems.TranslationX = -300;
                    await ErrorItems.TranslateTo(ErrorItems.TranslationX + 320, ErrorItems.TranslationY, 150);
                    await ErrorItems.TranslateTo(ErrorItems.TranslationX - 50, ErrorItems.TranslationY, 40);
                    await ErrorItems.TranslateTo(ErrorItems.TranslationX + 50, ErrorItems.TranslationY, 50);
                    await ErrorItems.TranslateTo(ErrorItems.TranslationX - 20, ErrorItems.TranslationY, 40);
                    Animation = false;
                }
                else
                {
                    ErrorItems.TranslationX = -300;
                }
        }

        private void ButtonRetry_Clicked(object sender, EventArgs e)
        {
            Inet.Check();
        }

        public async void ErrorVisible_Changed(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Animation)
                return;
            if (e.PropertyName == "IsVisible")
                if (ErrorFrame.IsVisible)
                {
                    Animation = true;
                    ErrorFrame.TranslationX = -300;
                    ButtonRetry.TranslationX = 300;

                    new Thread(async () =>
                    {
                        await ErrorFrame.TranslateTo(ErrorFrame.TranslationX + 320, ErrorFrame.TranslationY, 150);
                        await ErrorFrame.TranslateTo(ErrorFrame.TranslationX - 50, ErrorFrame.TranslationY, 40);
                        await ErrorFrame.TranslateTo(ErrorFrame.TranslationX + 50, ErrorFrame.TranslationY, 50);
                        await ErrorFrame.TranslateTo(ErrorFrame.TranslationX - 20, ErrorFrame.TranslationY, 40);
                    }).Start();

                    new Thread(async () =>
                    {
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
    }
}