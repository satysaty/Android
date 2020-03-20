using Company.Models;
using Company.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Company.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BuyPage : ContentPage
	{
        BuyViewModel viewModel;

        bool shackle;

        public BuyPage (Repair repair)
		{
			InitializeComponent ();

            //label1.Text = repair.Work.Name;
            //label3.Text = repair.GetPrice.ToString();
            //label2.Text = repair.Options.Count.ToString();
            BindingContext = this.viewModel = new BuyViewModel(repair, this);
		}

        private async void ActivityIndicator_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsRunning")
                if (ActivityIndicator.IsRunning)
                {
                    new Thread(() => Buy.FadeTo(0.0, 400)).Start();
                    await Buy.TranslateTo(Buy.TranslationX, Buy.TranslationY - 300, 400);  
                }
                else
                {
                    Buy.IsEnabled = false;
                    new Thread(() => Buy.FadeTo(1.0, 1000)).Start();
                    await Buy.TranslateTo(Buy.TranslationX, Buy.TranslationY + 300, 1000);
                    await Buy.TranslateTo(Buy.TranslationX, Buy.TranslationY - 7, 100);
                    await Buy.TranslateTo(Buy.TranslationX, Buy.TranslationY + 7, 150);             
                }
        }

        private void Buy_Clicked(object sender, EventArgs e)
        {
            if (Name.Text != null && Phone.Text != null)
            {
                viewModel.Repair.Phone = Phone.Text;
                viewModel.Repair.Name = Name.Text;
                viewModel.LoadItemsCommand.Execute(null);
            }
            else
            {
                Shackle();
                Name.Placeholder = "Введите ваше имя";
                Name.PlaceholderColor = Color.PaleVioletRed;
                Phone.Placeholder = "Введите ваш телефон";
                Phone.PlaceholderColor = Color.PaleVioletRed;
            }
            //Shackle();
        }

        public async void Shackle()
        {
            if (shackle)
                return;
            shackle = true;
            Buy.Scale = 1.0;
            new Thread(async () =>await Buy.ScaleTo(0.97,20)).Start();
            await Buy.TranslateTo(Buy.TranslationX + 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX - 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX + 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX - 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX + 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX - 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX + 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX - 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX + 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX - 5, Buy.TranslationY, 20);
            new Thread(async () => await Buy.ScaleTo(1.0, 20)).Start();
            shackle = false;
        }

        public async void ToMain()
        {
            if (shackle)
                return;
            shackle = true;
            Buy.Scale = 1.0;
            new Thread(async () => await Buy.ScaleTo(0.97, 20)).Start();
            await Buy.TranslateTo(Buy.TranslationX + 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX - 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX + 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX - 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX + 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX - 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX + 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX - 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX + 5, Buy.TranslationY, 20);
            await Buy.TranslateTo(Buy.TranslationX - 5, Buy.TranslationY, 20);
            new Thread(async () => await Buy.ScaleTo(1.0, 20)).Start();
            shackle = false;
        }

    }
}