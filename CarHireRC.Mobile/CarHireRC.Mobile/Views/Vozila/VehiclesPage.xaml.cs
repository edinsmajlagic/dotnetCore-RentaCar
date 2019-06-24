using CarHireRC.Mobile.ViewModels;
using CarHireRC.Mobile.ViewModels.Vozila;
using CarHireRC.Mobile.Views.Rezervacije;
using CarHireRC.Model.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHireRC.Mobile.Views.Vozila
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VehiclesPage : ContentPage
	{
        private VozilaViewModel model = null;
        public int KlijentID;
        public VehiclesPage (int Klijent)
		{
			InitializeComponent ();
            KlijentID = Klijent;
            BindingContext = model = new VozilaViewModel();
        }
        public VehiclesPage()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Automobil;

            await Navigation.PushAsync(new NewReservationPageOne(KlijentID,item.AutomobilId));
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {

            ListView sva = (ListView)FindByName("SvaVozila");
            ListView preporucena = (ListView)FindByName("PreporucenaVozila");


            StackLayout sl = (StackLayout)FindByName("sl");
            if (e.Value)
            {
                sl.Children.Remove(sva);
                if (!sl.Children.Contains(preporucena))
                    sl.Children.Add(preporucena);

                preporucena.IsVisible = true;
                preporucena.RowHeight = 110;
                sva.RowHeight = 0;
            }
            else
            {
                sl.Children.Remove(preporucena);

                if (!sl.Children.Contains(sva))
                    sl.Children.Add(sva);

                sva.IsVisible = true;
                sva.RowHeight = 110;
                preporucena.RowHeight = 0;
            }
        }

    }
}