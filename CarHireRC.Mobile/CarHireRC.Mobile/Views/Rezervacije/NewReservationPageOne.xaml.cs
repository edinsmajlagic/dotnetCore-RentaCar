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
            if (!model.Provjera)
            {
                await Application.Current.MainPage.DisplayAlert("Obavijest", "Upješno ste izvršili rezervaciju", "OK");
                Page p = Navigation.NavigationStack[Navigation.NavigationStack.Count-1];
                 Navigation.InsertPageBefore(new MyRidesPage(model.KlijentID),p);
                await Navigation.PopAsync();
            }
        }

        

       
        private async void Rezervacijado_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker rezervacijaod= (DatePicker)FindByName("rezervacijaod");
            DatePicker rezervacijado = (DatePicker)FindByName("rezervacijado");
            bool result = await model.CheckRezervacijaDo(rezervacijaod.Date,rezervacijado.Date);
            if (result)
            {
                rezervacijado.TextColor = Color.Red;
                await Application.Current.MainPage.DisplayAlert("Greška", "Nažalost odabrano vozilo je rezervisano za taj period. Molimo Vas da odaberete drugo vozilo ili smanjite broj dana .", "OK");

            }
            else
            {
                rezervacijado.TextColor = Color.Black;

            }
        }

        private void KaskoOsiguranjeSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            Label l=(Label)FindByName("cijenaosiguranja");
            Switch sw=(Switch)FindByName("kaskoOsiguranjeSwitch");

            if (sw.IsToggled)
                l.IsVisible = true;
            else
                l.IsVisible = false;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();

        }


    }
}