using Company.Models;
using Company.Services;
using Company.ViewModels;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        List<MenuCategory> menuItems;

        public City city;

        public City City
        {
            get
            {
                if (city == null)
                    city = new City();

                return city;
            }
        }
        
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<MenuCategory>
            {
                new MenuCategory {Id = 0, Title="Услуги", Icon="repairs.png" },
                new MenuCategory {Id = 1, Title="Мастера", Icon="masters.png" },
                new MenuCategory {Id = 2, Title="Контакты", Icon="contacts.png" },
                new MenuCategory {Id = 3, Title="Помощь", Icon="help.png" },
                //new MenuCategory {Id = 4, Title="О компании", Icon="about_company.png" },
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = ((MenuCategory)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }

        protected override void OnAppearing()
        {
            ChangeCity.Text = City.Name;
            //  city.Text = CityName;
            base.OnAppearing();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SelectCityPage(), true);
        }
    }
}