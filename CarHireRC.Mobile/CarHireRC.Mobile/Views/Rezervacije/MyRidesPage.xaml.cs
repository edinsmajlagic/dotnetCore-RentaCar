using CarHireRC.Mobile.ViewModels.Rezervacije;
using CarHireRC.Model.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHireRC.Mobile.Views.Rezervacije
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyRidesPage : ContentPage
	{
        public int KlijentID;
        private RezervacijeViewModel model = null;

		public MyRidesPage (int Klijent)
		{
			InitializeComponent ();
            KlijentID = Klijent;
            BindingContext = model = new RezervacijeViewModel(KlijentID);
		}
        public MyRidesPage()
        {
            InitializeComponent();
           
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as RezervacijaRentanja;
           

            await Navigation.PushAsync(new ReservationDetailsPage(item));
        }

      

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {

            ListView zavrsene = (ListView)FindByName("ZavrseneRezervacije");
            ListView uToku = (ListView)FindByName("UTokuRezervacije");
            

            StackLayout sl = (StackLayout)FindByName("sl");
            if (e.Value)
            {
                sl.Children.Remove(uToku);
                if(!sl.Children.Contains(zavrsene))
                    sl.Children.Add(zavrsene);

                zavrsene.IsVisible = true;
                zavrsene.RowHeight = 130;
                uToku.RowHeight = 0;
            }
            else
            {
                sl.Children.Remove(zavrsene);

                if (!sl.Children.Contains(uToku))
                    sl.Children.Add(uToku);

                uToku.IsVisible = true;
                uToku.RowHeight = 130;
                zavrsene.RowHeight = 0;
            }
        }
    }
}