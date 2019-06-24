using CarHireRC.Mobile.Views.Rezervacije;
using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarHireRC.Mobile.ViewModels.Rezervacije
{
    public class NovaRezervacijaViewModel:BaseViewModel
    {
        private readonly APIService _rezervacijeService = new APIService("RezervacijaRentanja");
        private readonly APIService _vozilaService = new APIService("Automobil");
        private readonly APIService _racuniService = new APIService("Racun");

        public int KlijentID,VoziloID;

        public NovaRezervacijaViewModel(int Klijent,int Vozilo)
        {
            KlijentID = Klijent;
            VoziloID = Vozilo;
            RezervisiCommand = new Command(async () => await Rezervisi());
            InitCommand = new Command(async () => await Init());

        }

        public NovaRezervacijaViewModel()
        {
            
        }
        public RezervacijaRentanjaUpsertRequest novaRezervacija { get; set; } = new RezervacijaRentanjaUpsertRequest();


        public string _lokacijaPreuzimanja = string.Empty;
        public string LokacijaPreuzimanja
        {
            get { return _lokacijaPreuzimanja; }
            set { SetProperty(ref _lokacijaPreuzimanja, value); }
        }

        public string _opis = string.Empty;
        public string Opis
        {
            get { return _opis; }
            set { SetProperty(ref _opis, value); }
        }

        public bool _vracanjeUPoslovnicu;
        public bool VracanjeUposlovnicu
        {
            get { return _vracanjeUPoslovnicu; }
            set { SetProperty(ref _vracanjeUPoslovnicu, value); }
        }

        bool _provjera = false;
        public bool Provjera
        {
            get { return _provjera; }
            set { SetProperty(ref _provjera, value); }
        }

        public DateTime _rezervacijaOd=DateTime.Now;
        public DateTime RezervacijaOd
        {
            get { return _rezervacijaOd; }
            set {
                SetProperty(ref _rezervacijaOd, value);
                if (value != null)
                    RezervacijaDo = value;
            }
        }

        public DateTime _rezervacijaDo = DateTime.Now;
        public DateTime RezervacijaDo
        {
            get { return _rezervacijaDo; }
            set {
                SetProperty(ref _rezervacijaDo, value);

            }
        }

        public bool _kaskoOsiguranje;
        public bool KaskoOsiguranje
        {
            get { return _kaskoOsiguranje; }
            set { SetProperty(ref _kaskoOsiguranje, value); }
        }

        public string _cijenaOsiguranja;
        public string CijenaOsiguranja
        {
            get { return _cijenaOsiguranja; }
            set { SetProperty(ref _cijenaOsiguranja, value); }
        }

        public byte[] _slikaThumb;
        public byte[] SlikaThumb
        {
            get { return _slikaThumb; }
            set { SetProperty(ref _slikaThumb, value); }
        }

        public decimal _cijenaIznajmljivanja;
        public decimal CijenaIznajmljivanja
        {
            get { return _cijenaIznajmljivanja; }
            set { SetProperty(ref _cijenaIznajmljivanja, value); }
        }

        public string _voziloInformacije = string.Empty;
        public string VoziloInformacije
        {
            get { return _voziloInformacije; }
            set { SetProperty(ref _voziloInformacije, value); }
        }

        public ICommand RezervisiCommand { get; set; }
        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
           var vozilo = await _vozilaService.GetById<Model.Models.Automobil>(VoziloID);

            CijenaOsiguranja ="+ "+ vozilo.CijenaKaskoOsiguranja.ToString()+" KM" ;
        }

        public async Task Rezervisi()
        {
            IsBusy = true;
            bool vehiclereserved = await CheckRezervacijaDo(RezervacijaOd,RezervacijaDo);

            //Ako vozilo nema rezervaciju za taj period
            if (!vehiclereserved)
            {
                novaRezervacija.KlijentId = KlijentID;
                novaRezervacija.DatumKreiranja = DateTime.Now;
                if (RezervacijaOd != null && RezervacijaDo != null)
                {
                    novaRezervacija.RezervacijaOd = RezervacijaOd;
                    novaRezervacija.RezervacijaDo = RezervacijaDo;

                    TimeSpan brojDana = RezervacijaDo - RezervacijaOd;
                    novaRezervacija.Popust = 0;

                    //Automatsko definisanje popusta
                    //Uposlenik (Desktop) može izmjeniti iznos popusta uređivanjem rezervacije
                    if (brojDana.Days >= 3 && brojDana.Days < 5)
                        novaRezervacija.Popust = 0.1;
                    else if (brojDana.Days >= 5 && brojDana.Days < 10)
                        novaRezervacija.Popust = 0.2;
                    else if (brojDana.Days >= 10)
                        novaRezervacija.Popust = 0.3;

                    if (VoziloID != 0)
                    {
                        var vozilo = await _vozilaService.GetById<Model.Models.Automobil>(VoziloID);

                        if(brojDana.Days==0)
                        novaRezervacija.Iznos = (vozilo.CijenaIznajmljivanja * 1);

                        else
                        novaRezervacija.Iznos = (vozilo.CijenaIznajmljivanja * brojDana.Days);

                        novaRezervacija.IznosSaPopustom = novaRezervacija.Iznos - (novaRezervacija.Iznos * (decimal)novaRezervacija.Popust);
                        
                        //Ako je uklučeno kasko osiguranje
                        if (KaskoOsiguranje)
                            novaRezervacija.IznosSaPopustom += (vozilo.CijenaKaskoOsiguranja * brojDana.Days);

                        novaRezervacija.AutomobilId = VoziloID;
                        SlikaThumb = vozilo.Slika;
                        CijenaIznajmljivanja = vozilo.CijenaIznajmljivanja;
                        VoziloInformacije = vozilo.ProizvodjacModel;
                    }
                }
                novaRezervacija.KaskoOsiguranje = KaskoOsiguranje;
                novaRezervacija.VracanjeUposlovnicu = VracanjeUposlovnicu;
                novaRezervacija.LokacijaPreuzimanja = LokacijaPreuzimanja;

                try
                {
                    //Dodaje račun za rezervaciju u bazu
                    var racun = new RacunUpsertRequest()
                    {
                        DatumIzdavanja = DateTime.Now,
                        UkupanIznos = novaRezervacija.IznosSaPopustom
                    };

                    var entityRacun = await _racuniService.Insert<Model.Models.Racun>(racun);

                    novaRezervacija.RacunId = entityRacun.RacunId;

                    //Dodaje rezervaciju
                    var entity = await _rezervacijeService.Insert<Model.Models.RezervacijaRentanja>(novaRezervacija);
                    if (entity != null)
                    {
                        entity.SlikaThumb = SlikaThumb;
                        entity.CijenaIznajmljivanja = CijenaIznajmljivanja;
                        entity.VoziloInformacije = VoziloInformacije;
                        if (entity.LokacijaPreuzimanja == "")
                            entity.LokacijaPreuzimanja = "Preuzimanje u poslovnici";

                        TimeSpan timeSpan = entity.RezervacijaOd.Date - DateTime.Now.Date;

                        //Ako je razlika početka rezervacije i današnjeg datuma manja od 2 dana
                        //postavi vozilo kao nedostupno
                        if (timeSpan.Days <= 2)
                        {
                            //Update podataka o vozilu sa rezervacije
                            var vozilo = await _vozilaService.GetById<Model.Models.Automobil>(entity.AutomobilId);
                            AutomobiliUPSERTtRequest voziloUpsertrequest = new AutomobiliUPSERTtRequest()
                            {
                                AutomobilId = vozilo.AutomobilId,
                                Boja = vozilo.Boja,
                                BrojSjedista = vozilo.BrojSjedista,
                                BrojVrata = vozilo.BrojVrata,
                                CijenaIznajmljivanja = vozilo.CijenaIznajmljivanja,
                                CijenaKaskoOsiguranja = vozilo.CijenaKaskoOsiguranja,
                                Dostupan = false,
                                EmisioniStandard = vozilo.EmisioniStandard,
                                GodinaProizvodnje = vozilo.GodinaProizvodnje,
                                Gorivo = vozilo.Gorivo,
                                KategorijaId = vozilo.KategorijaId,
                                Kubikaza = vozilo.Kubikaza,
                                ModelId = vozilo.ModelId,
                                Novo = vozilo.Novo,
                                Potrosnja = vozilo.Potrosnja,
                                Slika = vozilo.Slika,
                                SlikaThumb = vozilo.SlikaThumb,
                                SnagaMotora = vozilo.SnagaMotora,
                                Transmisija = vozilo.Transmisija
                            };

                            await _vozilaService.Update<Model.Models.Automobil>(entity.AutomobilId, voziloUpsertrequest);
                        }
                    }

                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
                }
            }
            else
            {
                //Ako uneseni podaci nisu validni
                _provjera = true;
                await Application.Current.MainPage.DisplayAlert("Greška", "Uneseni podaci nisu validni", "OK");

            }
        }


        //Provjera unesenog datuma rezervacije
        public async Task<bool> CheckRezervacijaDo(DateTime dateod,DateTime datedo)
        {
            bool postoji = false;
            RezervacijaRentanjaSearchRequest rezervacijaSearch = new RezervacijaRentanjaSearchRequest()
            {
                Otkazana = false,
                AutomobilId = VoziloID,
                RezervacijaOd=dateod
            };


            var rezervacije = await _rezervacijeService.Get<List<Model.Models.RezervacijaRentanja>>(rezervacijaSearch);

            //Ako ima rezervacija koje počinju u periodu od odabranog
            if (rezervacije.Count > 0)
            {
                foreach (var item in rezervacije)
                {
                    TimeSpan ts = item.RezervacijaOd - dateod;
                    //Ako je razlika početka postojeće rezervacije 
                    //i odabranog završetka nove manja ili jednaka jednom danu
                    if(ts.Days<=1)
                        postoji = true;

                }
            }
            _provjera = postoji;
            return postoji;
        }
    }
}
