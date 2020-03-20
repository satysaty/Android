using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Company.Views;
using System.Threading.Tasks;
using Plugin.Settings;
using Plugin.Connectivity;
using Company.Views.MenuViews;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Company
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            if (CrossSettings.Current.GetValueOrDefault("City", -1) == -1)
                MainPage = new SelectCityPage();
            else
                MainPage = new MainPage();
            //MainPage = new NavigationPage(new SellPage(new Models.Work() {Name="Тест работа", Id=1,CityId=0,Description="Описание", Price=1000 }));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
