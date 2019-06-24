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
    public partial class RegistrationPage : ContentPage
    {
        private RegisterViewModel model = null;
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = model = new RegisterViewModel();
        }

        protected  async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();

        }

        private async void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            Entry password = (Entry)FindByName("password");
            Entry passwordConfirm = (Entry)FindByName("passwordConfirm");

            if(password.Text !="" && password.Text != passwordConfirm.Text)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Lozinke se ne podudaraju", "OK");

            }
        }

        private async void Entry_Unfocused_Username(object sender, FocusEventArgs e)
        {
            Entry username = (Entry)FindByName("username");

            bool result =await model.CheckUsername(username.Text);

            if (result)
            {
                username.TextColor = Color.Red;
                await Application.Current.MainPage.DisplayAlert("Greška","Korisničko ime je zauzeto !", "OK");

            }
            else
            {
                username.TextColor = Color.Black;

            }
        }

        private async void Email_Unfocused(object sender, FocusEventArgs e)
        {
            Entry email = (Entry)FindByName("email");

            bool result = await model.CheckEmail(email.Text);

            if (result)
            {
                email.TextColor = Color.Red;
                await Application.Current.MainPage.DisplayAlert("Greška", "Email već postoji !", "OK");

            }
            else
            {
                email.TextColor = Color.Black;

            }
        }
    }
}