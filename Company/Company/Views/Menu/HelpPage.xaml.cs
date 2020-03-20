using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views.MenuViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HelpPage : ContentPage
	{
        bool ButAnim;

        bool ViewAnim;

		public HelpPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AnimateView();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ButAnim = false;
        }

        public void AnimateView()
        {
            if (ViewAnim)
                return;
            ViewAnim = true;
            Hide();
            Frame1Anim();
            Frame2Anim();
            Frame3Anim();
            Frame4Anim();
            ViewAnim = false;
        }

        private void Hide()
        {
            Frame1.IsVisible = false;
            Frame2.IsVisible = false;
            Frame3.IsVisible = false;
            Frame4.IsVisible = false;
            Frame5.IsVisible = false;
            Frame6.IsVisible = false;
        }

        private async void Frame6_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new MainPage();
            await Navigation.PushAsync(new MainCategoryPage(), true);
            ButAnim = false;
        }

        public async void Frame1Anim()
        {
            Frame1.TranslationY = -400;
            Frame1.Opacity = 0.0;
            await Task.Delay(1000);
            Frame1.IsVisible = true;
            Frame1.FadeTo(1.0, 600);
            await Frame1.TranslateTo(Frame1.TranslationX, Frame1.TranslationY + 750, 200);
            await Frame1.TranslateTo(Frame1.TranslationX, Frame1.TranslationY - 250, 400);
            await Frame1.TranslateTo(Frame1.TranslationX, Frame1.TranslationY - 100, 470);
        }

        public async void Frame2Anim()
        {
            Frame2.TranslationY = -300;
            Frame2.Opacity = 0.0;
            await Task.Delay(1700);
            Frame2.IsVisible = true;
            Frame2.FadeTo(1.0, 600);
            await Frame2.TranslateTo(Frame2.TranslationX, Frame2.TranslationY + 650, 200);
            await Frame2.TranslateTo(Frame2.TranslationX, Frame2.TranslationY - 250, 400);
            await Frame2.TranslateTo(Frame2.TranslationX, Frame2.TranslationY - 100, 470);
        }

        public async void Frame3Anim()
        {
            Frame3.TranslationY = -200;
            Frame3.Opacity = 0.0;
            await Task.Delay(2200);
            Frame3.IsVisible = true;
            Frame3.FadeTo(1.0, 600);
            await Frame3.TranslateTo(Frame3.TranslationX, Frame3.TranslationY + 550, 300);
            await Frame3.TranslateTo(Frame3.TranslationX, Frame3.TranslationY - 250, 400);
            await Frame3.TranslateTo(Frame3.TranslationX, Frame3.TranslationY - 100, 470);
        }
        public async void Frame4Anim()
        {
            Frame4.TranslationY = Frame4.TranslationY + 200;
            Frame4.Opacity = 0.0;
            await Task.Delay(3700);
            Frame4.IsVisible = true;
            Frame4.FadeTo(1.0, 600);
            await Frame4.TranslateTo(Frame4.TranslationX, Frame4.TranslationY - 210, 180);
            Frame4.TranslateTo(Frame4.TranslationX, Frame4.TranslationY + 10, 300);

            Frame3.TranslateTo(Frame3.TranslationX, Frame3.TranslationY - 15, 150);
            Frame3.RotateXTo(12.0, 150);
            await Task.Delay(150);
            Frame3.RotateXTo(0.0, 150);
            Frame3.TranslateTo(Frame3.TranslationX, Frame3.TranslationY + 15, 100);

            Frame2.TranslateTo(Frame2.TranslationX, Frame2.TranslationY - 15, 200);  
            Frame2.RotateXTo(-12.0, 200);
            await Task.Delay(200);
            Frame2.RotateXTo(0.0, 200);
            Frame2.TranslateTo(Frame2.TranslationX, Frame2.TranslationY + 15, 150);

            Frame1.TranslateTo(Frame1.TranslationX, Frame1.TranslationY - 15, 220);
            Frame1.RotateXTo(17.0, 220);
            await Task.Delay(220);
            Frame1.RotateXTo(0.0, 220);
            Frame1.TranslateTo(Frame1.TranslationX, Frame1.TranslationY + 15, 170);

            Frame5.IsVisible = true;
            Frame5.Opacity = 0.0;
            await Frame5.FadeTo(1.0,1500);

            Frame6.IsVisible = true;
            Frame6.Opacity = 0.0;
            await Frame6.FadeTo(1.0, 500);
            ButAnim = true;

            while (ButAnim)
            {
                await Frame6.ScaleTo(0.93,100);
                await Frame6.ScaleTo(1.0,100);
                await Task.Delay(1000);
            }
            //await Frame4.TranslateTo(Frame4.TranslationX, Frame4.TranslationY - 100, 600);
        }
    }
}