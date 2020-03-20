using Company.Views.MenuViews;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add(0, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case 0:
                        MenuPages.Add(id, new NavigationPage(new MainCategoryPage()));
                        break;
                    case 1:
                        MenuPages.Add(id, new NavigationPage(new MasterPage()));
                        break;
                    case 2:
                        MenuPages.Add(id, new NavigationPage(new ContactPage()));
                        break;
                    case 3:
                        MenuPages.Add(id, new NavigationPage(new HelpPage()));
                        break;
                    //case 4:
                    //    MenuPages.Add(id, new NavigationPage(new AboutPage()));
                    //    break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}