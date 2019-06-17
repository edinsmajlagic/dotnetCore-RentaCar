using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarHireRC.Mobile.ViewModels.Poruke
{
   public class PorukaViewModel:BaseViewModel
    {
        private readonly APIService _porukeService = new APIService("Poruka");

        int KlijentID;

        public PorukaViewModel(int Klijent)
        {
            KlijentID = Klijent;
            InitCommand = new Command(async () => await Init());

        }
        public PorukaViewModel()
        {
            InitCommand = new Command(async () => await Init());

        }

        public ObservableCollection<Model.Models.Poruka> listaPoruka { get; set; } = new ObservableCollection<Model.Models.Poruka>();
      

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            if (KlijentID > 0)
            {
                PorukaSearchRequest searchRequest = new PorukaSearchRequest();
                searchRequest.KlijentId = KlijentID;

                var list = await _porukeService.Get<IEnumerable<Model.Models.Poruka>>(searchRequest);

                listaPoruka.Clear();
                foreach (var item in list)
                {
                    listaPoruka.Add(item);
                }

            }
        }

        public async Task OznaciKaoProcitanu(Poruka poruka)
        {
                PorukaUpsertRequest porukaRequest = new PorukaUpsertRequest();
                porukaRequest.KlijentId = poruka.KlijentId;
                porukaRequest.UposlenikId = poruka.UposlenikId;
                porukaRequest.Naslov = poruka.Naslov;
                porukaRequest.Posiljaoc = poruka.Posiljaoc;
                porukaRequest.RezervacijaRentanjaId = poruka.RezervacijaRentanjaId;
                porukaRequest.Sadrzaj = poruka.Sadrzaj;
                porukaRequest.DatumVrijeme = poruka.DatumVrijeme;
                porukaRequest.PorukaId = poruka.PorukaId;
                porukaRequest.Procitano = true;

                 //Označi poruku kao pročitanu
                await _porukeService.Update<Model.Models.Poruka>(poruka.PorukaId,porukaRequest);
        }

    }
}
