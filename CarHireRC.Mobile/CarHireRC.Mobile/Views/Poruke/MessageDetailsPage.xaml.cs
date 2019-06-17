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
    public partial class MessageDetailsPage : ContentPage
    {
        public PorukaDetaljiViewModel model = null;
        public MessageDetailsPage(Poruka poruka)
        {
            InitializeComponent();
            BindingContext = model = new PorukaDetaljiViewModel()
            {
                Poruka=poruka
            };
        }

        public MessageDetailsPage()
        {

        }
        private async void ButtonOdgovori_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new NewMessagePage(model.Poruka));
        }
    }
}