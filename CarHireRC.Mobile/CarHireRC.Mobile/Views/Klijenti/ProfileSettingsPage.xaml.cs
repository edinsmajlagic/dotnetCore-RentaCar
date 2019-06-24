using CarHireRC.Mobile.ViewModels.Klijenti;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHireRC.Mobile.Views.Klijenti
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfileSettingsPage : ContentPage
	{
        private UserProfileViewModel model = null;
        int KlijentID;
		public ProfileSettingsPage (int id)
		{
			InitializeComponent ();
            KlijentID = id;
            BindingContext = model = new UserProfileViewModel()
            {
                KlijentID=id
            };

        }
        public ProfileSettingsPage()
        {
            InitializeComponent();
        }
        protected async override  void OnAppearing()
        {
            base.OnAppearing();
           await model.Init();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Greška", "Učitavanje slike nije dozvoljeno", "OK");
                return;
            }
            PickMediaOptions pick = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var file = await CrossMedia.Current.PickPhotoAsync(pick);
            if (file == null)
                return;
            Image i = (Image)FindByName("Slika");
            i.Source = ImageSource.FromStream(() => file.GetStream());

            MemoryStream ms = new MemoryStream();
            file.GetStream().CopyTo(ms);
            model._posiljaocSlika = ms.ToArray();
        }

        private async void PasswordConfirm_Unfocused(object sender, FocusEventArgs e)
        {
            Entry password = (Entry)FindByName("password");
            Entry passwordConfirm = (Entry)FindByName("passwordConfirm");

            if (password.Text != "" && password.Text != passwordConfirm.Text)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Lozinke se ne podudaraju", "OK");

            }
        }

        private async void ButtonSacuvaj_Clicked(object sender, EventArgs e)
        {
            if(!model.Provjera)
                await Application.Current.MainPage.DisplayAlert("Obavijest", "Uspješno ste izmjenili korisničke podatke", "OK");

        }
        private async void ButtonIzmjenaLozinke_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangePasswordPage(KlijentID));

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

        private async void Username_Unfocused(object sender, FocusEventArgs e)
        {
            Entry username = (Entry)FindByName("username");

            bool result = await model.CheckUsername(username.Text);

            if (result)
            {
                username.TextColor = Color.Red;
                await Application.Current.MainPage.DisplayAlert("Greška", "Korisničko ime je zauzeto !", "OK");

            }
            else
            {
                username.TextColor = Color.Black;

            }
        }
    }
}