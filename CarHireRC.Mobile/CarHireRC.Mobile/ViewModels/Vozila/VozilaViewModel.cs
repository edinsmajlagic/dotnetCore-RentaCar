using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarHireRC.Mobile.ViewModels.Vozila
{
    public class VozilaViewModel : BaseViewModel
    {
        private readonly APIService _vozilaService = new APIService("Automobil");
        private readonly APIService _kategorijaVozilaService = new APIService("KategorijaVozila");

        public VozilaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Automobil> VozilaList { get; set; } = new ObservableCollection<Automobil>();
        public ObservableCollection<KategorijaVozila> kategorijaVozila { get; set; } = new ObservableCollection<KategorijaVozila>();


        KategorijaVozila _selectedKategorijaVozila = null;

        public KategorijaVozila SelectedKategorijaVozila
        {
            get { return _selectedKategorijaVozila; }
            set
            {
                SetProperty(ref _selectedKategorijaVozila, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }


        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            if (kategorijaVozila.Count == 0)
            {
                var kategorijaVozilaList = await _kategorijaVozilaService.Get<List<KategorijaVozila>>(null);

                foreach (var kategorija in kategorijaVozilaList)
                {
                    kategorijaVozila.Add(kategorija);
                }
            }
            RezervacijaSearchRequest search = new RezervacijaSearchRequest();

            if (SelectedKategorijaVozila != null)
            {
                search.KategorijaId = _selectedKategorijaVozila.KategorijaId;
            }
            search.Dostupan = true;
            var list = await _vozilaService.Get<IEnumerable<Automobil>>(search);

                VozilaList.Clear();
                foreach (var vozilo in list)
                {
                    VozilaList.Add(vozilo);
                }
           
        }
    }
}
