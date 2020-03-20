using Company.Views;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Company.Services
{
    class Inet
    {
        INavigation Navigation;

        Command Command;

        bool Update;

        public Inet(INavigation nav, Command command)
        {
            Navigation = nav;

            Command = command;

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (Update)
                    Command.Execute(null);
                if (Navigation.ModalStack.Where(x => x is NoInternetPage).FirstOrDefault() != null)
                    await Navigation.PopModalAsync(true);
            }
            else
                if (Navigation.ModalStack.Where(x => x is NoInternetPage).FirstOrDefault() == null)
                await Navigation.PushModalAsync(new NoInternetPage(), true);
        }

        public async void Check(bool update=false)
        {
            if (update)
                Update = update;

            if (!CrossConnectivity.Current.IsConnected)
            {
                if (Navigation.ModalStack.Where(x => x is NoInternetPage).FirstOrDefault() == null)
                    await Navigation.PushModalAsync(new NoInternetPage(), true);
            }
            else
                Command.Execute(null);
        }
    }
}
