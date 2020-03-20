using Company.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views.MenuViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactPage : ContentPage
	{
        ContactViewModel viewModel;

        public ContactPage ()
		{
			InitializeComponent ();

            BindingContext = this.viewModel = new ContactViewModel();
		}

	}
}