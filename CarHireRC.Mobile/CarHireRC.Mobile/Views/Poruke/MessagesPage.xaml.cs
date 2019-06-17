using CarHireRC.Mobile.ViewModels.Poruke;
using CarHireRC.Model.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHireRC.Mobile.Views.Poruke
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MessagesPage : ContentPage
	{
        public int KlijentID;
        private PorukaViewModel model = null;
        public MessagesPage (int Klijent)
		{
			InitializeComponent ();
            
            KlijentID = Klijent;
            BindingContext = model = new PorukaViewModel(KlijentID);
        }
        public MessagesPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            

        }

        private async void Lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Poruka;

            if (item.Posiljaoc == "Uposlenik")
               await model.OznaciKaoProcitanu(item);
            await Navigation.PushAsync(new MessageDetailsPage(item));
        }
    }
}