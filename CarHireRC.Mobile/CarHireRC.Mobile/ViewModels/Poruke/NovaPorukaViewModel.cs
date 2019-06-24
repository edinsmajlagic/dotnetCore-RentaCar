using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarHireRC.Mobile.ViewModels.Poruke
{
    public class NovaPorukaViewModel:BaseViewModel
    {
        private readonly APIService _porukaService = new APIService("Poruka");



        public NovaPorukaViewModel(Poruka p)
        {
            PosaljiCommand = new Command(async () => await PosaljiPoruku());
        }

        public NovaPorukaViewModel()
        {

        }

       


        public PorukaUpsertRequest novaPoruka { get; set; } = new PorukaUpsertRequest();
        public Poruka Poruka { get; set; }

        public string _sadrzajPoruke = string.Empty;
        public string SadrzajPoruke
        {
            get { return _sadrzajPoruke; }
            set { SetProperty(ref _sadrzajPoruke, value); }
        }

        public byte[] _posiljaocSlikaThumb ;
        public byte[] PosiljaocSlikaThumb
        {
            get { return _posiljaocSlikaThumb; }
            set { SetProperty(ref _posiljaocSlikaThumb, value); }
        }

        public Command PosaljiCommand { get; }

     

        public async Task PosaljiPoruku()
        {

            novaPoruka.RezervacijaRentanjaId = Poruka.RezervacijaRentanjaId;
            novaPoruka.KlijentId = Poruka.KlijentId;
            novaPoruka.UposlenikId = Poruka.UposlenikId;
            novaPoruka.DatumVrijeme = DateTime.Now;
            novaPoruka.Naslov = Poruka.Naslov;
            novaPoruka.Procitano = false;
            novaPoruka.Posiljaoc = "Klijent";
            novaPoruka.Sadrzaj = SadrzajPoruke;

            try
            {
                await _porukaService.Insert<Model.Models.Poruka>(novaPoruka);

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");

            }
        }
    }
}
