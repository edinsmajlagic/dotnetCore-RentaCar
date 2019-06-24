using CarHireRC.Mobile.ViewModels.Klijenti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHireRC.Mobile.Views.Klijenti
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChangePasswordPage : ContentPage
	{
        private PasswordChangeViewModel model = null;
        public ChangePasswordPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new PasswordChangeViewModel
            {
                KlijentID = id
            };
		}
        public ChangePasswordPage()
        {
            InitializeComponent();
        }
        private async void ButtonSacuvaj_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.DisplayAlert("Obavijest", "Uspješno ste izmjenili lozinku", "OK");
            await Navigation.PopAsync();
        }

        private async void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            await model.OldPasswordCheck();
        }
    }
}