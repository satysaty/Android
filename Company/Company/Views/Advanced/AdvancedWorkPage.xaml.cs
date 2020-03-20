using Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views.Advanced
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdvancedWorkPage : ContentPage
	{
		public AdvancedWorkPage (Repair repair, IEnumerable<WorkOption> workOptions)
		{
			InitializeComponent ();

            Title = "Рассчитать точную стоимость";

            if (workOptions.FirstOrDefault() != null )
                if (!workOptions.FirstOrDefault().Last)
                    Content = new SelectAdView(repair, workOptions);
                else      
                    Content = new EndAdView(repair, workOptions);
		}
	}
}