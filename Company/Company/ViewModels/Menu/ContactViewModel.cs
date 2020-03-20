using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Company.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public ContactViewModel()
        {
            Title = "Наши контакты";

            //OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}