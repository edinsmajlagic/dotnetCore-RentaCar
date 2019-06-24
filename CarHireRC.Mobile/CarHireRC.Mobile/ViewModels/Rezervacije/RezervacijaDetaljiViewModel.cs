using CarHireRC.Mobile.Views;
using CarHireRC.Mobile.Views.Rezervacije;
using CarHireRC.Model.Models;
using CarHireRC.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarHireRC.Mobile.ViewModels.Rezervacije
{
    public class RezervacijaDetaljiViewModel:BaseViewModel
    {
        private readonly APIService _ocjeneService = new APIService("Ocjena");
        private readonly APIService _klijentiService = new APIService("Klijent");
        private readonly APIService _korisniciService = new APIService("Korisnik");
        private readonly APIService _porukeService = new APIService("Poruka");
        private readonly APIService _rezervacijeService = new APIService("RezervacijaRentanja");

        public RezervacijaDetaljiViewModel()
        {

        }


        public async Task OtkaziRezervaciju()
        {

            TimeSpan timeSpan = rezervacijaRentanja.RezervacijaOd - DateTime.Now;
            //Moguće otkazati rezervaciju samo 3 dana prije početka rezervacije

            if (timeSpan.Days > 3)
            {
                _provjera = true;
                RezervacijaRentanjaUpsertRequest request = new RezervacijaRentanjaUpsertRequest()
                {
                    RezervacijaRentanjaId = rezervacijaRentanja.RezervacijaRentanjaId,
                    AutomobilId = rezervacijaRentanja.AutomobilId,
                    DatumKreiranja = rezervacijaRentanja.DatumKreiranja,
                    Iznos = rezervacijaRentanja.Iznos,
                    RezervacijaOd = rezervacijaRentanja.RezervacijaOd,
                    RezervacijaDo = rezervacijaRentanja.RezervacijaDo,
                    IznosSaPopustom = rezervacijaRentanja.IznosSaPopustom,
                    KaskoOsiguranje = rezervacijaRentanja.KaskoOsiguranje,
                    KlijentId = rezervacijaRentanja.KlijentId,
                    LokacijaPreuzimanja = rezervacijaRentanja.LokacijaPreuzimanja,
                    VracanjeUposlovnicu = rezervacijaRentanja.VracanjeUposlovnicu,
                    RacunId = rezervacijaRentanja.RacunId,
                    Opis = rezervacijaRentanja.Opis,
                    Popust = rezervacijaRentanja.Popust,
                    Otkazana = true
                };

                try
                {
                    var entity = await _rezervacijeService.Update<Model.Models.RezervacijaRentanja>(rezervacijaRentanja.RezervacijaRentanjaId, request);

                    if (entity != null)
                    {
                        KorisniciSearchRequest korisniciSearch = new KorisniciSearchRequest();

                        //Slanje poruke samo korisnicima sa ulogom "Uposlenik"
                        List<string> uloge = new List<string>();
                        uloge.Add("Uposlenik");

                        korisniciSearch.Status = true;
                        korisniciSearch.uloge = uloge;

                        var korisnici = await _korisniciService.Get<List<Model.Models.Korisnici>>(korisniciSearch);


                        foreach (var korisnik in korisnici)
                        {

                            var klijent = await _klijentiService.GetById<Model.Models.Klijent>(rezervacijaRentanja.KlijentId);
                            var uposlenik = await _korisniciService.GetById<Model.Models.Korisnici>(korisnik.KorisnikId);

                            PorukaUpsertRequest porukaUpsert = new PorukaUpsertRequest
                            {
                                RezervacijaRentanjaId = rezervacijaRentanja.RezervacijaRentanjaId,
                                KlijentId = rezervacijaRentanja.KlijentId,
                                UposlenikId = korisnik.KorisnikId,
                                DatumVrijeme = DateTime.Now,
                                Naslov = "Rezervacija otkazana",
                                Procitano = false,
                                Posiljaoc = "Uposlenik",
                                Sadrzaj = "Pozdrav " + uposlenik.ImePrezime + ", \n"
                                         + " Rezervacija klijenta " + klijent.Ime + " " + klijent.Prezime
                                         + " kreirana dana " + rezervacijaRentanja.DatumKreiranja.ToShortDateString()
                                         + " je otkazana."
                            };

                            //Slanje poruke za uposlenika sa UposlenikID
                            await _porukeService.Insert<Model.Models.Poruka>(porukaUpsert);
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
                _provjera = false;
                await Application.Current.MainPage.DisplayAlert("Greška", "Nije moguće otkazati rezervaciju koja počinje za manje od tri dana", "OK");
            }

        }

        public RezervacijaRentanja rezervacijaRentanja{ get; set; }

        bool _provjera = false;
        public bool Provjera
        {
            get { return _provjera; }
            set { SetProperty(ref _provjera, value); }
        }
        public OcjenaUpsertRequest novaOcjena { get; set; } = new OcjenaUpsertRequest();

        public async Task  DodajOcjenu(int RezervacijaID,float ocjena)
        {
            novaOcjena.Ocjena1 = (int)ocjena;
            novaOcjena.DatumEvidentiranja = DateTime.Now;
            novaOcjena.RezervacijaRentanjaId = RezervacijaID;

            try
            {
                var entity = await _ocjeneService.Insert<Model.Models.Ocjena>(novaOcjena);
                var rezervacija = await _rezervacijeService.GetById<Model.Models.RezervacijaRentanja>(RezervacijaID);

                if (entity != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Obavijest", "Upješno ste ocijenili rezervaciju", "OK");
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");


            }
        }

    }
}
