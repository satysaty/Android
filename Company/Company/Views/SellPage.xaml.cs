using Company.Models;
using Company.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SellPage : TabbedPage
	{
		public SellPage (Work work)
		{
			InitializeComponent ();
            Children.Add(new PricePage(work));
            Children.Add(new WorkMastersPage(work));
        }
    }
}