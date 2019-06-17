using CarHireRC.Mobile.ViewModels.Rezervacije;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHireRC.Mobile.Views.Rezervacije
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewReservationPageOne : ContentPage
	{
        private NovaRezervacijaViewModel model = null;
        int KlijentID,VoziloID;
		public NewReservationPageOne (int Klijent,int Vozilo)
		{
            KlijentID = Klijent;
            VoziloID = Vozilo;
            InitializeComponent ();
            BindingContext = model = new NovaRezervacijaViewModel(KlijentID,Vozilo);
		}
        public NewReservationPageOne()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Application.Current.MainPage.DisplayAlert("Obavijest", "Upješno ste izvršili rezervaciju", "OK");
            await Navigation.PushAsync(new MyRidesPage(model.KlijentID));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }

        
    }
}