using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Company.ViewModels
{
    public class ThanksViewModel : BaseViewModel
    {
        public ThanksViewModel()
        {
            Title = "Thanks";
        }

        public ICommand OpenWebCommand { get; }
    }
}