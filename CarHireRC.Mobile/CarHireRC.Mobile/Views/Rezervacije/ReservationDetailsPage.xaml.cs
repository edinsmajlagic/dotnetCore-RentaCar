using CarHireRC.Mobile.CustomViews;
using CarHireRC.Mobile.ViewModels.Rezervacije;
using CarHireRC.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHireRC.Mobile.Views.Rezervacije
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReservationDetailsPage : ContentPage
	{
        public RezervacijaDetaljiViewModel model = null;
		public ReservationDetailsPage (RezervacijaRentanja rezervacija )
		{
			InitializeComponent();
            BindingContext = model = new RezervacijaDetaljiViewModel()
            {
                rezervacijaRentanja=rezervacija
            };

            if (rezervacija.RezervacijaOd > DateTime.Now)
            {
                Grid g = (Grid)FindByName("Red4Button");
                g.IsVisible = true;
            }
            else
            {
                Grid g = (Grid)FindByName("Red4Ocjena");
                g.IsVisible = true;
            }
        }


        private async void OnRatingChanged(object sender, float e)
        {
            CustomRatingBar customRatingBar = (CustomRatingBar)FindByName("customRatingBar");
            customRatingBar.IsEnabled = false;
            customRatingBar.Rating = e;
            int rezervacijaId = model.rezervacijaRentanja.RezervacijaRentanjaId;

           await model.DodajOcjenu(rezervacijaId,e);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool izbor = await Application.Current.MainPage.DisplayAlert(null, "Da li ste sigurni da želite otkazati rezervaciju ?", "Da", "Ne");
            if (izbor)
            {
                await model.OtkaziRezervaciju();
                await Application.Current.MainPage.DisplayAlert("Obavijest", "Rezervacija otkazana", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}