using CarHireRC.Mobile.ViewModels.Poruke;
using CarHireRC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHireRC.Mobile.Views.Poruke
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewMessagePage : ContentPage
	{
        public NovaPorukaViewModel model = null;

		public NewMessagePage (Poruka p)
		{
            InitializeComponent();
            BindingContext = model = new NovaPorukaViewModel(p)
            {
                Poruka=p
            };

        }

        public NewMessagePage()
        {
            InitializeComponent();
        }

        private async void ButtonPosalji_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.DisplayAlert("Obavijest", "Upješno ste poslali poruku", "OK");
            //await Navigation.PushAsync(new MessagesPage(model.novaPoruka.KlijentId));
            await Navigation.PopAsync();
        }
    }
}